using System;
using System.Collections.ObjectModel;

namespace Organiser
{
    /// <summary>
    /// Коллекция с задачами.
    /// </summary>
    [Serializable]
    public class ProblemObservable : ObservableCollection<Problem>
    {
        public void Full(Object map)
        {
            ProblemObservable pO = null;

            try
            {
                pO = (ProblemObservable)map;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                return;
            }

            foreach (Problem p in pO)
            {
                this.Add(p);
            }
        }
    }

    /// <summary>
    /// Коллекция с исполнеными задачами
    /// </summary>
    public class ProblemsExecuteObservable : ObservableCollection<ProblemExecute>
    {

    }

    /// <summary>
    /// Представляет исполненную задачу
    /// </summary>
    public class ProblemExecute : BaseClass
    {
        private DateTime _dateTimeExecute;
        private string _messageExecute;

        public ProblemExecute(DateTime _dt, string msg)
        {
            _dateTimeExecute = _dt;
            _messageExecute = msg;
        }

        #region- Properties -
        public DateTime DateTimeExecute
        {
            get { return _dateTimeExecute; }
            set
            {
                if (value != null)
                {
                    _dateTimeExecute = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string MessageExecute
        {
            get { return _messageExecute; }
            set
            {
                _messageExecute = value;
                NotifyPropertyChanged();
            }
        }
        #endregion
    }

}