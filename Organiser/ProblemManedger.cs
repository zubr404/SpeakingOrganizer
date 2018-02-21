using System;
using System.Linq;
using System.Collections.Generic;
using System.Speech.Synthesis;
using System.Windows.Threading;
using ExtensionMethods;

namespace Organiser
{
    public class ProblemManedger : BaseClass, IDisposable
    {
        ProblemObservable _problemAllObs;
        ProblemsExecuteObservable _problemExecutedObs;
        List<Problem> _problemForSpeech;

        SpeechSynthesizer synthesizer;  // синтез речи

        DispatcherTimer check_timer;
        DispatcherTimer readText_timer;
        DispatcherTimer pause_timer;  // для задержки при включенном сигнале
        TimeSpan Interval;

        //
        SettingsClass settClass;

        //
        private string[] readList;

        #region -Constructor-
        public ProblemManedger(ProblemObservable _probObs, ProblemsExecuteObservable _probExecutObs, SpeechSynthesizer _synthesizer, SettingsClass _settClass)
        {
            _problemAllObs = _probObs;
            _problemExecutedObs = _probExecutObs;
            _problemForSpeech = new List<Problem>();

            synthesizer = _synthesizer;
            settClass = _settClass;

            #region -Timers-
            Interval = new TimeSpan(0, 0, 1);
            check_timer = new DispatcherTimer();
            check_timer.Interval = Interval;
            check_timer.Tick += Check_timer_Tick;
            check_timer.Start();

            pause_timer = new DispatcherTimer();
            pause_timer.Interval = new TimeSpan(0, 0, 2);
            pause_timer.Tick += Pause_timer_Tick;

            readText_timer = new DispatcherTimer();
            readText_timer.Interval = new TimeSpan(0, 30, 10); // должно быть из SettingsClass
            readText_timer.Tick += ReadText_timer_Tick;
            //readText_timer.Start();
            #endregion

            readList = Speak.LoadText() ?? (new string[0]);
            CheckProblemStart();
        }
        #endregion

        #region -Properties-
        public ProblemObservable ProblemAllObs
        {
            get { return _problemAllObs; }
            set
            {
                if (value != null)
                {
                    _problemAllObs = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public ProblemsExecuteObservable ProblemExecuteObs
        {
            get { return _problemExecutedObs; }
            set
            {
                if (value != null)
                {
                    _problemExecutedObs = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion

        #region -Event-
        #region - Tаймер для обработки заданий по времени -
        private void Check_timer_Tick(object sender, EventArgs e)
        {
            bool _play_flag = true;
                    
            CheckProblem(() => 
            {
                if (settClass.SignalSett)
                {
                    if (_play_flag)
                    {
                        Speak.PlaySoundDirectory(settClass.SignalNameSett, true, pause_timer);
                        _play_flag = false;
                    }
                }
                else
                {
                    pause_timer.Start();
                }
            });
        }

        // проверка исполнения заданий
        private void CheckProblem(Action _func)
        {
            Problem item;
            bool? _end_task;
            DateTime _executeDateTime;

            for (int i = 0; i < ProblemAllObs.Count; i++)
            {
                _end_task = null;
                item = ProblemAllObs[i];

                // если напоминание исполнилось
                if (item.EventChange(ref _end_task, out _executeDateTime))
                {
                    _func();
                    _problemForSpeech.Add(item);

                    ProblemAllObs.Sort((a, b) => a.StartDateTime.CompareTo(b.StartDateTime));
                    SerializeA.Serializes(ProblemAllObs, ProblemAllObs.GetType().ToString());
                }

                // если больше не будет повторяться
                if (_end_task != null && (bool)_end_task)
                {
                    ProblemAllObs.RemoveAt(i);
                    SerializeA.Serializes(ProblemAllObs, ProblemAllObs.GetType().ToString());
                }
            }
        }

        // проверка исполнения задания при первом запуске
        private void CheckProblemFirst()
        {
            bool search_prob = true;
            Problem item;
            bool? _end_task;
            DateTime _executeDateTime;

            for (; search_prob; )
            {
                search_prob = false;

                for (int i = 0; i < ProblemAllObs.Count; i++)
                {
                    _end_task = null;
                    item = ProblemAllObs[i];

                    // если напоминание исполнилось
                    if (item.EventChange(ref _end_task, out _executeDateTime))
                    {
                        search_prob = true;
                    }

                    // если больше не будет повторяться
                    if (_end_task != null && (bool)_end_task)
                    {
                        ProblemAllObs.RemoveAt(i);
                    }
                }
            }
            SerializeA.Serializes(ProblemAllObs, ProblemAllObs.GetType().ToString());
        }
        private void CheckProblemStart()
        {
            foreach (Problem item in ProblemAllObs)
            {
                DateTime _today = DateTime.Now.Date;
                DateTime _startProb = item.StartDateTime;

                if (_startProb.Date < _today)
                {
                    item.StartDateTime = new DateTime(_today.Year, _today.Month, _today.Day, _startProb.Hour, _startProb.Minute, _startProb.Second);
                }
            }
        }
        #endregion

        #region -Таймер пауза-
        void Pause_timer_Tick(object sender, EventArgs e)
        {
            string _msg;

            foreach (Problem item in _problemForSpeech)
            {
                _msg = item.MessageText;

                ProblemExecuteObs.Add(new ProblemExecute(item.StartDateTime, _msg));
                Speak.Speakmain(synthesizer, _msg, item.Speek, settClass.SpeekAllSett);
                Speak.MessageWindow(_msg, item.MessageMindow);
            }
            _problemForSpeech.Clear();

            pause_timer.Stop();
        }
        #endregion

        #region -Таймер для чтения из файла-
        void ReadText_timer_Tick(object sender, EventArgs e)
        {
            int i = Properties.Settings.Default.save_index_read;

            if (i < readList.Count())
            {
                Speak.SpeakFileText(synthesizer, readList, i);
                i++;
            }
            else
            {
                i = 0;
            }

            Properties.Settings.Default.save_index_read = i;
            Properties.Settings.Default.Save();
        }
        #endregion

        #endregion

        #region -Method-
        
        #endregion

        #region - Implement IDisposable -
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                synthesizer.Dispose();
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