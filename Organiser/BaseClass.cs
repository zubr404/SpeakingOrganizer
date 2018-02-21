using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Organiser
{
    [Serializable]
    public abstract class BaseClass : INotifyPropertyChanged
    {

        #region INotifyPropertyChanged
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}