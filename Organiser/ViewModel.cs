using System;
using System.IO;
using System.Collections.ObjectModel;
using System.Linq;
using System.Speech.Synthesis;
using System.Windows.Controls;
using ExtensionMethods;

namespace Organiser
{
    public class ProblemViewModel : BaseClass, IDisposable
    {
        private RepositoryClasses _repoClasses;

        private ProblemObservable _problemsObs;
        private ProblemsExecuteObservable _problemExecuteObs;
        private Problem _selectedProblem;
        private ProblemExecute _selectedExecute;
        private Problem _sourceProblem;

        private SettingsClass _settClass;
        private SpeechSynthesizer _synthesizer;

        // $
        private bool _isEnabledPropertiesProblem;
        private bool _isEnabledMissedReminder;
        private bool _isEnabledSettVoice;
        private bool _isEnabledSettAll;
        private bool _detailsMode;

        //
        private int _countExecute;
        private string _nearestProblem; // описание ближайшего задания

        //
        private TimeSummaryObservable _timeSumObs;
        private DateTime _dateForIndicator;

        #region -Конструктор-
        public ProblemViewModel()
        {
            _repoClasses = new RepositoryClasses();
            _problemsObs = _repoClasses.ProblemObs;
            _problemsObs.CollectionChanged += _problemsObs_CollectionChanged;
            _problemExecuteObs = _repoClasses.ProblemExecuteObs;
            _problemExecuteObs.CollectionChanged += _problemExecuteObs_CollectionChanged;

            _settClass = _repoClasses.SettClass;
            _synthesizer = _repoClasses.Synthesizer;

            //
            _timeSumObs = new TimeSummaryObservable(TimePeriodType._day, DateTime.Now);
            _timeSumObs.AddTimeSummary(_problemsObs, TimePeriodType._day);

            //
            _dateForIndicator = DateTime.Now;
            NearestProblem = NearestProblemSet(_problemsObs[0]);
        }
        #endregion

        #region-Properties-
        public SettingsClass SettClass
        {
            get { return _settClass; }
            set
            {
                if (value != null)
                {
                    _settClass = value;
                    base.NotifyPropertyChanged();
                }
            }
        }
        public ProblemObservable ProblemsObs
        {
            get { return _problemsObs; }
            set
            {
                if (value != null)
                {
                    _problemsObs = value;
                    base.NotifyPropertyChanged();
                }
            }
        }
        public ProblemsExecuteObservable ProblemsExecuteObs
        {
            get { return _problemExecuteObs; }
            set
            {
                if(value != null)
                {
                    _problemExecuteObs = value;
                    base.NotifyPropertyChanged();
                }
            }
        }
        public TimeSummaryObservable TimeSumObservable
        {
            get { return _timeSumObs ?? (_timeSumObs = new TimeSummaryObservable(TimePeriodType._day, _dateForIndicator)); }
            set
            {
                if (value != null)
                {
                    _timeSumObs = value;
                    base.NotifyPropertyChanged();
                }
            }
        }
        public Problem SourceProblem
        {
            get { return _sourceProblem; }
            set
            {
                if (value != null)
                {
                    _sourceProblem = value;
                    base.NotifyPropertyChanged();
                }
            }
        }
        public Problem SelectedProblem
        {
            get { return _selectedProblem; }
            set
            {
                if (value != null)
                {
                    _selectedProblem = value;
                    base.NotifyPropertyChanged();
                }
            }
        }
        public ProblemExecute SelectedExecute
        {
            get { return _selectedExecute; }
            set
            {
                if (value != null)
                {
                    _selectedExecute = value;
                    base.NotifyPropertyChanged();
                }
            }
        }
        public bool IsEnabledPropertiesProblem
        {
            get { return _isEnabledPropertiesProblem; }
            set
            {
                if (value != _isEnabledPropertiesProblem)
                {
                    _isEnabledPropertiesProblem = value;
                    base.NotifyPropertyChanged();
                    ProblemsObs.Sort((a, b) => a.StartDateTime.CompareTo(b.StartDateTime));
                }
            }
        }
        public bool IsEnabledMissedReminder
        {
            get { return _isEnabledMissedReminder; }
            set
            {
                if (value != _isEnabledMissedReminder)
                {
                    _isEnabledMissedReminder = value;
                    base.NotifyPropertyChanged();
                }
            }
        }
        public bool IsEnabledSettVoice
        {
            get { return _isEnabledSettVoice; }
            set
            {
                if (value != _isEnabledSettVoice)
                {
                    _isEnabledSettVoice = value;
                    base.NotifyPropertyChanged();
                }
            }
        }
        public bool IsEnabledSettAll
        {
            get { return _isEnabledSettAll; }
            set
            {
                if (value != _isEnabledSettAll)
                {
                    _isEnabledSettAll = value;
                    base.NotifyPropertyChanged();
                }
            }
        }
        public bool DetailsMode
        {
            get { return _detailsMode; }
            set
            {
                if (value != _detailsMode)
                {
                    _detailsMode = value;
                    base.NotifyPropertyChanged();
                }
            }
        }
        public int CountExecute
        {
            get { return _countExecute; }
            set
            {
                _countExecute = value;
                base.NotifyPropertyChanged();
            }
        }
        public DateTime DateForIndicator
        {
            get { return _dateForIndicator; }
            set
            {
                if (value != null && value >= DateTime.Now.Date)
                {
                    _dateForIndicator = value;
                    base.NotifyPropertyChanged();
                    TimeSumObservable = new TimeSummaryObservable(TimePeriodType._day, _dateForIndicator);
                    TimeSumObservable.AddTimeSummary(_problemsObs, TimePeriodType._day);
                }
            }
        }
        public string NearestProblem
        {
            get { return _nearestProblem ?? (_nearestProblem = "Не найдено."); }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _nearestProblem = value;
                    base.NotifyPropertyChanged();
                }
            }
        }
        #endregion

        #region-Command-

        #region-Add/Save Problem (+ button Save)-
        private RelayCommand _addProblemCommand;
        private RelayCommand _saveProblemCommand;

        public RelayCommand AddProblemCommand
        {
            get
            {
                return _addProblemCommand ?? (_addProblemCommand = new RelayCommand(
                    (object arg) =>
                    {
                        SourceProblem = new Problem();
                        IsEnabledPropertiesProblem = true;
                    }
                    ));
            }
        }
        public RelayCommand SaveProblemCommand
        {
            get
            {
                return _saveProblemCommand ?? (_saveProblemCommand = new RelayCommand(
                    (object arg) =>
                    {
                        if (!ProblemsObs.Any(x => x.ID == SourceProblem.ID))
                        {
                            ProblemsObs.Add((Problem)SourceProblem.Clone());
                        }
                        else
                        {
                            for (int i = 0; i < ProblemsObs.Count; i++ ) 
                            {
                                if (ProblemsObs[i].ID == SourceProblem.ID)
                                {
                                    ProblemsObs[i] = (Problem)SourceProblem.Clone();
                                    SelectedProblem = ProblemsObs[i];
                                }
                            }
                            
                        }
                        IsEnabledPropertiesProblem = false;
                        _repoClasses.ProblemObs = ProblemsObs;
                    }
                    ));
            }
        }
        #endregion

        #region -Remove / Edit-
        #region-Remove-
        private RelayCommand _removeProblemCommand;
        public RelayCommand RemoveProblemCommand
        {
            get
            {
                return _removeProblemCommand ?? (_removeProblemCommand = new RelayCommand(RemoveProblem, CanProblem));
            }
        }

        private void RemoveProblem(object arg)
        {
            _problemsObs.Remove(SelectedProblem);
            _repoClasses.ProblemObs = _problemsObs;
            DetailsMode = false;
        }
        #endregion

        #region-Edit-
        private RelayCommand _editProblemComand;
        public RelayCommand EditProblemComand
        {
            get
            {
                return _editProblemComand ?? (_editProblemComand = new RelayCommand(EditProblem, CanProblem));
            }
        }

        private void EditProblem(object arg)
        {
            SourceProblem = (Problem)SelectedProblem.Clone();
            IsEnabledPropertiesProblem = true;
        }

        #endregion

        private bool CanProblem(object arg)
        {
            if (SelectedProblem == null)
            {
                return false;
            }

            var problem = FindProblem(SelectedProblem);

            if (problem == null)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region -Remove/RemoveAll execute-
        private RelayCommand _removeExecuteCommand;
        public RelayCommand RemoveExecuteCommand
        {
            get { return _removeExecuteCommand ?? (_removeExecuteCommand = new RelayCommand(RemoveExecute, CanExecute)); }
        }
        private void RemoveExecute(object arg)
        {
            _problemExecuteObs.Remove(SelectedExecute);

            if (_problemExecuteObs.Count == 0)
            {
                IsEnabledMissedReminder = false;
            }
        }
        private bool CanExecute(object arg)
        {
            if (SelectedExecute == null)
            {
                return false;
            }

            var execute = FindProblem(SelectedExecute);

            if (execute == null)
            {
                return false;
            }

            return true;
        }

        private RelayCommand _removeAllExecuteCommand;
        public RelayCommand RemoveAllExecuteCommand
        {
            get
            {
                return _removeAllExecuteCommand ?? (_removeAllExecuteCommand = new RelayCommand(
                    (object arg) => 
                    {
                        _problemExecuteObs.Clear();
                        IsEnabledMissedReminder = false;
                    }
                    ));
            }
        }
        #endregion

        #region -Скрыть/покзать детали строк DataGrid-
        private RelayCommand _hiddenProblemDetails;
        public RelayCommand HiddenProblemDetails
        {
            get
            {
                return _hiddenProblemDetails ?? (_hiddenProblemDetails = new RelayCommand(
                    (object arg) =>
                    {
                        if (DetailsMode)
                        {
                            DetailsMode = false;
                            return;
                        }
                        if (!DetailsMode)
                        {
                            if (SelectedProblem != null)
                            {
                                DetailsMode = true;
                            }
                            return;
                        }
                    }
                    ));
            }
        }

        #endregion

        #region-Управление областью параматры задачи-
        // кнопка назад в области параметров задачи
        private RelayCommand _stepBackCommand;
        public RelayCommand StepBackCommand
        {
            get
            {
                return _stepBackCommand ?? (_stepBackCommand = new RelayCommand(
                    (object arg) => { IsEnabledPropertiesProblem = false; }
                    ));
            }
        }
        #endregion

        #region -Скрыть / показать пропущенные напоминания-
        private RelayCommand _hiddenMissedReminder;
        public RelayCommand HiddenMissedReminder
        {
            get
            {
                return _hiddenMissedReminder ?? (_hiddenMissedReminder = new RelayCommand(
                    (object arg) => 
                    {
                        if (IsEnabledMissedReminder)
                        {
                            IsEnabledMissedReminder = false;
                            return;
                        }
                        if (!IsEnabledMissedReminder)
                        {
                            if (_problemExecuteObs.Count > 0)
                            {
                                IsEnabledMissedReminder = true;
                            }
                            return;
                        }
                    }
                    ));
            }
        }
        #endregion

        // НАСТРОЙКИ
        #region -Общие настройки-
        // скрыть/показать панель
        private RelayCommand _showSettAllCommand;
        public RelayCommand ShowSettAllCommand
        {
            get
            {
                return _showSettAllCommand ?? (_showSettAllCommand = new RelayCommand(
                    (object arg) => 
                    {
                        IsEnabledSettAll = true;
                    }
                    ));
            }
        }

        // кнопка слушать
        private RelayCommand _hearSetSignalCommand;
        public RelayCommand HearSetSignalCommand
        {
            get
            {
                return _hearSetSignalCommand ?? (_hearSetSignalCommand = new RelayCommand(
                    (object arg) => 
                    {
                        Speak.PlaySoundTest(_settClass.SignalNameSett);
                    }
                    ));
            }
        }
        #endregion

        #region -Настроки голоса-
        // скрыть/показать панель
        private RelayCommand _showSettVoiceCommand;
        public RelayCommand ShowSettVoiceCommand
        {
            get
            {
                return _showSettVoiceCommand ?? (_showSettVoiceCommand = new RelayCommand(
                    (object arg) => 
                    {
                        IsEnabledSettVoice = true;
                    }
                    ));
            }
        }

        // кнопка слушать
        private RelayCommand _hearSetVoiceCommand;
        public RelayCommand HearSetVoiceCommand
        {
            get
            {
                return _hearSetVoiceCommand ?? (_hearSetVoiceCommand = new RelayCommand(
                    (object arg) =>
                    {
                        Speak.Speakmain(_synthesizer, "В лесу родилась елочка, в лесу она росла. Зимой и летом стройная, зеленая была.", true);
                    }
                    ));
            }
        }
        #endregion

        #region -Kнопка готово-
        private RelayCommand _hiddenSettVoiceCommand;
        public RelayCommand HiddenSettVoiceCommand
        {
            get
            {
                return _hiddenSettVoiceCommand ?? (_hiddenSettVoiceCommand = new RelayCommand(
                    (object arg) =>
                    {

                        IsEnabledSettVoice = false;
                        IsEnabledSettAll = false;
                    }
                    ));
            }
        }
        #endregion
        //*--*--*--*--*--*--*

        #region -Кнопки переключения месяцев на индикаторе занятости-
        private RelayCommand _stepUpDateIndicatorCommand;
        public RelayCommand StepUpDateIndicatorCommand
        {
            get
            {
                return _stepUpDateIndicatorCommand ?? (_stepUpDateIndicatorCommand = new RelayCommand(
                    (object arg) =>
                    {
                        DateForIndicator = _dateForIndicator.AddMonths(1);
                    }
                    ));
            }
        }
        private RelayCommand _stepDownDateIndicatorCommand;
        public RelayCommand StepDownDateIndicatorCommand
        {
            get
            {
                return _stepDownDateIndicatorCommand ?? (_stepDownDateIndicatorCommand = new RelayCommand(
                    (object arg) =>
                    {
                        DateForIndicator = _dateForIndicator.AddMonths(-1);
                    }
                    ));
            }
        }
        #endregion

        #endregion

        #region-Method-
        private Problem FindProblem(Problem findProbl)
        {
            Problem result = null;

            if (findProbl != null)
            {
                foreach (Problem p in _problemsObs)
                {
                    if (p.ID == findProbl.ID)
                    {
                        result = p;
                    }
                }
            }

            return result;
        }
        private ProblemExecute FindProblem(ProblemExecute findExecut)
        {
            ProblemExecute result = null;

            if (findExecut != null)
            {
                foreach (ProblemExecute p in _problemExecuteObs)
                {
                    if (p.Equals(findExecut))
                    {
                        result = p;
                    }
                }
            }

            return result;
        }

        private string NearestProblemSet(Problem _prob = null)
        {
            string value;

            if (_prob != null)
            {
                value = _prob.StartDateTime + "\n" + _prob.MessageText;
            }
            else
            {
                value = String.Empty;
            }

            return value;
        }
        #endregion

        #region -Event-
        // обработка изменения ProblemExecuteObs
        void _problemExecuteObs_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            CountExecute = _problemExecuteObs.Count();
        }

        // обработка изменения ProblemObservable
        void _problemsObs_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            _timeSumObs.AddTimeSummary(_problemsObs, TimePeriodType._day);
            NearestProblem = NearestProblemSet(_problemsObs[0]);
        }
        #endregion

        #region - Implement IDisposable -
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repoClasses.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }







    /// <summary>
    /// Репозиторий классов
    /// </summary>
    public class RepositoryClasses : IDisposable
    {
        private ProblemObservable _problemObs;
        private ProblemsExecuteObservable _problemExecuteObs;
        private ProblemManedger _problemManedger;

        //
        SettingsClass _settClass;
        SpeechSynthesizer _synthesizer;  // синтез речи

        #region-Constructor-
        public RepositoryClasses()
        {
            // 1
            DeserializesObject();
            // 2
            _problemExecuteObs = new ProblemsExecuteObservable();
            // 3
            VoiceSynthes();
            SignalNameCollection();
            // 4
            _problemManedger = new ProblemManedger(_problemObs, _problemExecuteObs, _synthesizer, _settClass);

            //test
            
        }
        #endregion

        #region -Properties-
        public ProblemObservable ProblemObs
        {
            get { return _problemObs; }
            set
            {
                if (value != null)
                {
                    _problemObs = value;
                    SerializeA.Serializes(_problemObs, _problemObs.GetType().ToString());
                }
            }
        }
        public ProblemsExecuteObservable ProblemExecuteObs
        {
            get { return _problemExecuteObs; }
            set
            {
                if (value != null)
                {
                    _problemExecuteObs = value;
                }
            }
        }
        public ProblemManedger ProbManedger
        {
            get { return _problemManedger; }
            set
            {
                if (value != null)
                {
                    _problemManedger = value;
                }
            }
        }
        public SettingsClass SettClass
        {
            get { return _settClass; }
            set
            {
                if (value != null)
                {
                    _settClass = value;
                }
            }
        }
        public SpeechSynthesizer Synthesizer
        {
            get { return _synthesizer; }
        }
        #endregion

        #region -Method-
        /// <summary>
        /// Десериализация сохраненных объектов
        /// </summary>
        private void DeserializesObject()
        {
            _problemObs = new ProblemObservable();
            _problemObs = (ProblemObservable)SerializeA.Deserializes(_problemObs.GetType().ToString(), _problemObs);

            _settClass = new SettingsClass();
            _settClass = (SettingsClass)SerializeA.Deserializes(_settClass.GetType().ToString(), _settClass);
            _settClass.PropertyChanged += SettClass_PropertyChanged;
        }

        /// <summary>
        /// Создаем экземпляр SpeechSynthesizer
        /// и заполняем List из SettingsClass с именами голосов
        /// </summary>
        private void VoiceSynthes()
        {
            _synthesizer = new SpeechSynthesizer();
            var voicelist = _synthesizer.GetInstalledVoices();
            _settClass.VoiceNameList.Clear();

            foreach (var item in voicelist)
            {
                _settClass.VoiceNameList.Add(item.VoiceInfo.Name);
            }

            _synthesizer.Rate = _settClass.SpeedSett;
            _synthesizer.Volume = _settClass.VolumeSet;
            _synthesizer.SetOutputToDefaultAudioDevice();

            try
            {
                _synthesizer.SelectVoice(_settClass.VoiceNameSett);
            }
            catch (Exception)
            {
                _synthesizer.SelectVoice(voicelist[0].VoiceInfo.Name);
            }
        }

        /// <summary>
        /// Создаем коллекцию с именами файлов мелодий сигнала
        /// </summary>
        private void SignalNameCollection()
        {
            _settClass.SignalNameList.Clear();
            try
            {
                string[] dirs = Directory.GetFiles(Directory.GetCurrentDirectory() + @"\Sound\", "*.wav", SearchOption.AllDirectories);
                foreach (string dir in dirs)
                {
                    _settClass.SignalNameList.Add(dir);
                }
            }
            catch (Exception)
            {
              
            }
        }
        #endregion

        #region -Handler events-
        //
        void SettClass_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "VoiceNameSett":
                    _synthesizer.SelectVoice(_settClass.VoiceNameSett);
                    break;

                case "SpeedSett":
                    _synthesizer.Rate = _settClass.SpeedSett;
                    break;

                case "VolumeSet":
                    _synthesizer.Volume = _settClass.VolumeSet;
                    break;
            }
        }

        #endregion

        #region - Implement IDisposable -
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _problemManedger.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }


}