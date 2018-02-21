using System;
using System.Collections.Generic;

namespace Organiser
{
    [Serializable]
    public class SettingsClass : BaseClass
    {
        // общие настроки
        private bool _signal;
        private string _signalName;
        private bool _speekAll;
        private List<string> _signalNameList;

        // настройка речи
        private string _voiceName;
        private int _volume;
        private int _speed;
        private List<string> _voiceNameList;

        // чтение из файла
        private bool _readText;

        #region -Properties-
        //
        public bool SignalSett
        {
            get { return _signal; }
            set
            {
                _signal = value;
                base.NotifyPropertyChanged();
                SerializeThis();
            }
        }
        public string SignalNameSett
        {
            get { return _signalName ?? (_signalName = "Alarm01.wav"); }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _signalName = value;
                    base.NotifyPropertyChanged();
                    SerializeThis();
                }
            }
        }
        public bool SpeekAllSett
        {
            get { return _speekAll; }
            set
            {
                _speekAll = value;
                base.NotifyPropertyChanged();
                SerializeThis();
            }
        }
        public List<string> SignalNameList
        {
            get { return _signalNameList ?? (_signalNameList = new List<string>()); }
            set
            {
                if (value != null)
                {
                    _signalNameList = value;
                    base.NotifyPropertyChanged();
                    SerializeThis();
                }
            }
        }

        //
        public string VoiceNameSett
        {
            get { return _voiceName ?? (_voiceName = "Microsoft Anna"); }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _voiceName = value;
                    base.NotifyPropertyChanged();
                    SerializeThis();
                }
            }
        }
        public int VolumeSet
        {
            get { return _volume; }
            set
            {
                if (value >= 0)
                {
                    _volume = value;
                    base.NotifyPropertyChanged();
                    SerializeThis();
                }
            }
        }
        public int SpeedSett
        {
            get { return _speed; }
            set
            {
                _speed = value;
                base.NotifyPropertyChanged();
                SerializeThis();
            }
        }
        public List<string> VoiceNameList
        {
            get
            {
                return _voiceNameList ?? (_voiceNameList = new List<string>());
            }
            set
            {
                if (value != null)
                {
                    _voiceNameList = value;
                    base.NotifyPropertyChanged();
                    SerializeThis();
                }
            }
        }

        //
        public bool ReadText
        {
            get { return _readText; }
            set
            {
                _readText = value;
                base.NotifyPropertyChanged();
                SerializeThis();
            }
        }

        #endregion

        #region -Method-
        private void SerializeThis()
        {
            SerializeA.Serializes(this, this.GetType().ToString());
        }
        #endregion
    }
}