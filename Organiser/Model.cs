using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Organiser
{

    /// <summary>
    /// Класс. Представляет данные о задаче.
    /// </summary>
    [Serializable]
    public class Problem : BaseClass, ICloneable
    {
        CultureInfo culture;
        int countReplayMemory;

        long id;
        DateTime startDateTime; // начальная дата
        DateTime doneDateTime; // дата время окончания выполнения
        bool errorDone;
        DateTime startDate;
        int startHour;
        int startMinute;
        int startSecond;
        int doneHour;
        int doneMinute;
        int doneSecond;

        // продолжительность задания
        TimeSpan durationProblem;
        bool errorDuration;
        int durationHour;
        int durationMinute;
        int durationSecond;

        DateTime endDateTime; // дата окончания повторения
        TimeSpan interval; // интервал повторения

        string messageText;

        bool replay;
        bool replayEveryday;
        bool replayEveryweek;
        bool replayEverymonth;
        bool replayEveryyear;
        bool replayOther;

        // окончание повторения
        bool endingNever;
        bool endingCount;
        int countReplays;
        bool endingDate;

        // дни недели
        List<DayOfWeek> dayOfweek_map;
        bool monday;
        bool tuesday;
        bool wednesday;
        bool thursday;
        bool friday;
        bool saturday;
        bool sunday;

        // сводка
        private string summaryRrob;

        // дополнительные натройки задания
        bool speek;
        bool message_window;

        #region -Implement IClonable-
        public object Clone()
        {
            Problem clone = (Problem)this.MemberwiseClone();
            clone.culture = new CultureInfo("ru-RU");
            clone.dayOfweek_map = new List<DayOfWeek>(7);
            foreach (var item in this.dayOfweek_map)
            {
                clone.dayOfweek_map.Add(item);
            }

            return clone;
        }
        #endregion

        #region -конструктор-
        public Problem()
        {
            id = DateTime.Now.Ticks;
            startDate = DateTime.Now.Date;
            startHour = DateTime.Now.Hour;
            startMinute = DateTime.Now.Minute;
            startSecond = DateTime.Now.Second;
            DateTimeCompile(startHour, startMinute, startSecond);

            doneHour = startHour;
            doneMinute = startMinute;
            doneSecond = startSecond;
            DoneDateTimeCompile(doneHour, doneMinute, doneSecond);

            durationHour = 0;
            durationMinute = 0;
            durationSecond = 0;
            DurationCompile(durationHour, durationMinute, durationSecond);

            replay = false;
            endDateTime = new DateTime(9999, 12, 31, 0, 0, 0);
            interval = new TimeSpan(0, 0, 0, 0);
            dayOfweek_map = new List<DayOfWeek>(7);

            culture = new CultureInfo("ru-RU");
        }
        #endregion

        #region- PROPERTIES -
        public long ID
        {
            get { return id; }
        }

        // старт задания
        public DateTime StartDateTime
        {
            get { return startDateTime; }
            set 
            {
                startDateTime = value;
                base.NotifyPropertyChanged();
                SetSummaryProb();
            }
        }
        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                DateTimeCompile(startHour, startMinute, startSecond);

                if (endingDate)
                {
                    if (endDateTime <= startDateTime)
                    {
                        EndDateTime = startDateTime.AddDays(1);
                    }
                }

                base.NotifyPropertyChanged();
                SetSummaryProb();
            }
        }
        public int StartHour
        {
            get { return startHour; }
            set
            {
                if (value >= 0 && value < 24)
                {
                    startHour = value;
                    DateTimeCompile(startHour, startMinute, startSecond);
                    base.NotifyPropertyChanged();
                    DoneHour = startHour;
                    SetSummaryProb();
                }
            }
        }
        public int StartMinute
        {
            get { return startMinute; }
            set
            {
                if (value >= 0 && value < 60)
                {
                    startMinute = value;
                    DateTimeCompile(startHour, startMinute, startSecond);
                    base.NotifyPropertyChanged();
                    DoneMinute = startMinute;
                    SetSummaryProb();
                }
            }
        }
        public int StartSecond
        {
            get { return startSecond; }
            set
            {
                if (value >= 0 && value < 60)
                {
                    startSecond = value;
                    DateTimeCompile(startHour, startMinute, startSecond);
                    base.NotifyPropertyChanged();
                    DoneSecond = startSecond;
                    SetSummaryProb();
                }
            }
        }

        // окoнчание выполнения
        public DateTime DoneDateTime
        {
            get { return doneDateTime; }
            set
            {
                if (value.CompareTo(doneDateTime) != 0)
                {
                    if (value >= startDateTime)
                    {
                        doneDateTime = value;
                        base.NotifyPropertyChanged();
                        SetSummaryProb();

                        TimeSpan _ts = doneDateTime.Subtract(startDateTime);
                        DurationCompile(_ts.Hours, _ts.Minutes, _ts.Seconds);
                        ErrorDone = false;
                    }
                    else
                    {
                        DoneDateTime = startDateTime;
                        ErrorDone = true;
                    }
                }
            }
        }
        public int DoneHour
        {
            get { return doneHour; }
            set
            {
                if (value != doneHour && value >= 0 && value < 24)
                {
                    doneHour = value;
                    DoneDateTimeCompile(doneHour, doneMinute, doneSecond);
                    base.NotifyPropertyChanged();
                }
            }
        }
        public int DoneMinute
        {
            get { return doneMinute; }
            set
            {
                if (value != doneMinute && value >= 0 && value < 60)
                {
                    doneMinute = value;
                    DoneDateTimeCompile(doneHour, doneMinute, doneSecond);
                    base.NotifyPropertyChanged();
                }
            }
        }
        public int DoneSecond
        {
            get { return doneSecond; }
            set
            {
                if (value != doneSecond && value >= 0 && value < 60)
                {
                    doneSecond = value;
                    DoneDateTimeCompile(doneHour, doneMinute, doneSecond);
                    base.NotifyPropertyChanged();
                }
            }
        }
        public bool ErrorDone
        {
            get { return errorDone; }
            set
            {
                errorDone = value;
                base.NotifyPropertyChanged();
            }
        }
        
        // продолжительность задания
        public TimeSpan DurationProblem
        {
            get { return durationProblem; }
            set
            {
                if (value.CompareTo(durationProblem) != 0)
                {
                    if (startDateTime.Add(value) <= startDateTime.Date.Add(new TimeSpan(23, 59, 59)))
                    {
                        durationProblem = value;
                        base.NotifyPropertyChanged();
                        SetSummaryProb();

                        DateTime _dt = startDateTime.Add(durationProblem);
                        DoneDateTimeCompile(_dt.Hour, _dt.Minute, _dt.Second);
                        ErrorDuration = false;
                    }
                    else
                    {
                        DurationProblem = new TimeSpan(0, 0, 0);
                        DoneDateTime = startDateTime;
                        ErrorDuration = true;
                    }
                }
            }
        }

        public int DurationHour
        {
            get { return durationHour; }
            set
            {
                if (value != durationHour && value < 24 && value >= 0)
                {
                    durationHour = value;
                    base.NotifyPropertyChanged();
                    DurationCompile(durationHour, durationMinute, durationSecond);
                }
            }
        }
        public int DurationMinute
        {
            get { return durationMinute; }
            set
            {
                if (value != durationMinute && value <= 59 && value >= 0)
                {
                    durationMinute = value;
                    base.NotifyPropertyChanged();
                    DurationCompile(durationHour, durationMinute, durationSecond);
                }
            }
        }
        public int DurationSecond
        {
            get { return durationSecond; }
            set
            {
                if (value != durationSecond && value <= 59 && value >= 0)
                {
                    durationSecond = value;
                    base.NotifyPropertyChanged();
                    DurationCompile(durationHour, durationMinute, durationSecond);
                }
            }
        }
        public bool ErrorDuration
        {
            get { return errorDuration; }
            set
            {
                errorDuration = value;
                base.NotifyPropertyChanged();
            }
        }






        // повторение
        public bool Replay
        {
            get { return replay; }
            set
            {
                if (value)
                {
                    if (!replayEveryday & !replayEveryweek & !replayEverymonth & !replayEveryyear & !replayOther)
                    {
                        ReplayEveryday = true;
                    }

                    if (!endingNever & !endingCount & !endingDate)
                    {
                        EndingNever = true;
                    }
                }

                replay = value;
                base.NotifyPropertyChanged();
                SetSummaryProb();
            }
        }
        public bool ReplayEveryday
        {
            get { return replayEveryday; }
            set
            {
                if (value)
                {
                    Interval = new TimeSpan(1, 0, 0, 0);
                }
                replayEveryday = value;
                base.NotifyPropertyChanged();
                SetSummaryProb();
            }
        }
        public bool ReplayEveryweek
        {
            get { return replayEveryweek; }
            set
            {
                if (value == replayEveryweek) { return; }
                if (value)
                {
                    Interval = new TimeSpan(7, 0, 0, 0);

                    switch (DateTime.Now.DayOfWeek)
                    {
                        case DayOfWeek.Friday:
                            Friday = true;
                            break;
                        case DayOfWeek.Monday:
                            Monday = true;
                            break;
                        case DayOfWeek.Saturday:
                            Saturday = true;
                            break;
                        case DayOfWeek.Sunday:
                            Sunday = true;
                            break;
                        case DayOfWeek.Thursday:
                            Thursday = true;
                            break;
                        case DayOfWeek.Tuesday:
                            Tuesday = true;
                            break;
                        case DayOfWeek.Wednesday:
                            Wednesday = true;
                            break;
                    }
                }
                replayEveryweek = value;
                base.NotifyPropertyChanged();
                SetSummaryProb();
            }
        }
        public bool ReplayEverymonth
        {
            get { return replayEverymonth; }
            set
            {
                replayEverymonth = value;
                base.NotifyPropertyChanged();
                if (replayEverymonth)
                {
                    Interval = (new DateTime(StartDate.Year, StartDate.Month + 1, StartDate.Day, 0, 0, 0)) - (new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, 0, 0, 0));
                }
                SetSummaryProb();
            }
        }
        public bool ReplaysEveryyear
        {
            get { return replayEveryyear; }
            set
            {
                replayEveryyear = value;
                base.NotifyPropertyChanged();
                if (replayEveryyear)
                {
                    Interval = (new DateTime(StartDate.Year + 1, StartDate.Month, StartDate.Day, 0, 0, 0)) - (new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, 0, 0, 0));
                }
                SetSummaryProb();
            }
        }
        public bool ReplayOther
        {
            get { return replayOther; }
            set
            {
                if (value && value != replayOther)
                {
                    Interval = new TimeSpan(1, 0, 0, 0);
                }
                replayOther = value;
                base.NotifyPropertyChanged();
                SetSummaryProb();
            }
        }
        public TimeSpan Interval
        {
            get { return interval; }
            set
            {
                if (value < TimeSpan.MaxValue & value > TimeSpan.MinValue)
                {
                    interval = value;
                    base.NotifyPropertyChanged();
                    SetSummaryProb();
                }
            }
        }

        // дни недели
        public bool Monday
        {
            get { return monday; }
            set
            {
                DayOfWeekControl(value, DayOfWeek.Monday);
                monday = value;
                base.NotifyPropertyChanged();
                SetSummaryProb();
                CalcIntervalWeek();
            }
        }
        public bool Tuesday
        {
            get { return tuesday; }
            set
            {
                DayOfWeekControl(value, DayOfWeek.Tuesday);
                tuesday = value;
                base.NotifyPropertyChanged();
                SetSummaryProb();
                CalcIntervalWeek();
            }
        }
        public bool Wednesday
        {
            get { return wednesday; }
            set
            {
                DayOfWeekControl(value, DayOfWeek.Wednesday);
                wednesday = value;
                base.NotifyPropertyChanged();
                SetSummaryProb();
                CalcIntervalWeek();
            }
        }
        public bool Thursday
        {
            get { return thursday; }
            set
            {
                DayOfWeekControl(value, DayOfWeek.Thursday);
                thursday = value;
                base.NotifyPropertyChanged();
                SetSummaryProb();
                CalcIntervalWeek();
            }
        }
        public bool Friday
        {
            get { return friday; }
            set
            {
                DayOfWeekControl(value, DayOfWeek.Friday);
                friday = value;
                base.NotifyPropertyChanged();
                SetSummaryProb();
                CalcIntervalWeek();
            }
        }
        public bool Saturday
        {
            get { return saturday; }
            set
            {
                DayOfWeekControl(value, DayOfWeek.Saturday);
                saturday = value;
                base.NotifyPropertyChanged();
                SetSummaryProb();
                CalcIntervalWeek();
            }
        }
        public bool Sunday
        {
            get { return sunday; }
            set
            {
                DayOfWeekControl(value, DayOfWeek.Sunday);
                sunday = value;
                base.NotifyPropertyChanged();
                SetSummaryProb();
                CalcIntervalWeek();
            }
        }
        public List<DayOfWeek> DayOfWeekList
        {
            get { return dayOfweek_map; }
        }

        // окнчание повторения
        public bool EndingNever
        {
            get { return endingNever; }
            set
            {
                if (value)
                {
                    EndDateTime = new DateTime(9999, 12, 31, 0, 0, 0);
                }
                endingNever = value;
                base.NotifyPropertyChanged();
                SetSummaryProb();
            }
        }
        public bool EndingCount
        {
            get { return endingCount; }
            set
            {
                endingCount = value;
                base.NotifyPropertyChanged();
                SetSummaryProb();
            }
        }
        public int CountReplays
        {
            get { return countReplays; }
            set
            {
                if (value > 0)
                {
                    countReplays = value;
                    base.NotifyPropertyChanged();
                    SetSummaryProb();
                }
            }
        }
        public bool EndingDate
        {
            get { return endingDate; }
            set
            {
                if (value && value != endingDate)
                {
                    EndDateTime = DateTime.Now.AddDays(1);
                }
                endingDate = value;
                base.NotifyPropertyChanged();
                SetSummaryProb();
            }
        }
        public DateTime EndDateTime
        {
            get { return endDateTime; }
            set
            {
                if (value > startDateTime)
                {
                    endDateTime = value;
                }
                else
                {
                    endDateTime = startDateTime.AddDays(1);
                }
                base.NotifyPropertyChanged();
                SetSummaryProb();
            }
        }

        // описание задачи
        public string MessageText
        {
            get { return messageText; }
            set
            {
                messageText = value;
                base.NotifyPropertyChanged();
                SetSummaryProb();
            }
        }

        // сводка
        public string SummaryProb
        {
            get { return summaryRrob; }
            set
            {
                summaryRrob = value;
                base.NotifyPropertyChanged();
            }
        }

        // дополнительные настройки
        public bool Speek
        {
            get { return speek; }
            set
            {
                speek = value;
                base.NotifyPropertyChanged();
                SetSummaryProb();
            }
        }
        public bool MessageMindow
        {
            get { return message_window; }
            set
            {
                message_window = value;
                base.NotifyPropertyChanged();
            }
        }

        #endregion

        #region -Method-

        /// <summary>
        /// Формирует стартовую дату
        /// </summary>
        /// <param name="hour">часы</param>
        /// <param name="minute">минуты</param>
        /// <param name="second">секунды</param>
        private void DateTimeCompile(int hour, int minute, int second)
        {
            StartDateTime = startDate.Add(new TimeSpan(hour, minute, second));
            CalcIntervalMonthYear();
        }

        /// <summary>
        /// Формирует дату окончания выполнения
        /// </summary>
        /// <param name="hour">часы</param>
        /// <param name="minute">минуты</param>
        /// <param name="second">секунды</param>
        private void DoneDateTimeCompile(int hour, int minute, int second)
        {
            DoneDateTime = startDateTime.Date.Add(new TimeSpan(hour, minute, second));
        }

        /// <summary>
        /// Формирует продолжительность задания
        /// </summary>
        /// <param name="hour">часы</param>
        /// <param name="minute">минуты</param>
        /// <param name="second">секунды</param>
        private void DurationCompile(int hour, int minute, int second)
        {
            DurationProblem = new TimeSpan(hour, minute, second);
        }

        /// <summary>
        /// Расчитывает Interval для replayEverymonth и replayEveryyear
        /// </summary>
        private void CalcIntervalMonthYear()
        {
            if (replayEverymonth)
            {
                Interval = (new DateTime(StartDate.Year, StartDate.Month + 1, StartDate.Day, 0, 0, 0)) - (new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, 0, 0, 0));
            }
            if (replayEveryyear)
            {
                Interval = (new DateTime(StartDate.Year + 1, StartDate.Month, StartDate.Day, 0, 0, 0)) - (new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, 0, 0, 0));
            }
        }

        /// <summary>
        /// Расчитывает Interval для replayEveryweek
        /// </summary>
        private void CalcIntervalWeek()
        {
            DateTime _tomorrow = DateTime.Now.Date.AddDays(1);
            DayOfWeek _dayOfWeekToday = _tomorrow.DayOfWeek;
            int i = 1;

            for (; i < 7; i++)
            {
                if (dayOfweek_map.Exists(x => x == _dayOfWeekToday))
                {
                    break;
                }

                _tomorrow = _tomorrow.AddDays(1);
                _dayOfWeekToday = _tomorrow.DayOfWeek;
            }
            Interval = new TimeSpan(i, 0, 0, 0);
        }

        /// <summary>
        /// Расчитывает следующую дату срабатывания
        /// </summary>
        private void SetNextDateTime()
        {
            StartDateTime += Interval;
        }

        /// <summary>
        /// Управление коллекцией dayOfweek_map
        /// </summary>
        /// <param name="value">истина или ложь</param>
        /// <param name="day">день недели</param>
        private void DayOfWeekControl(bool value, DayOfWeek day)
        {
            if (value)
            {
                if (!dayOfweek_map.Exists(x => x == day))
                {
                    dayOfweek_map.Add(day);
                }
            }
            else
            {
                dayOfweek_map.Remove(day);
            }
        }

        /// <summary>
        /// Формирует сводную строку
        /// </summary>
        private void SetSummaryProb()
        {
            SummaryProb = id + "\nСработает: " + startDateTime + "\nПродолжительность: " + durationProblem + "\nОкончание повторения: " + doneDateTime;

            if (!replay)
            {
                SummaryProb += "\nНе повторяется.";
            }
            else
            {
                SummaryProb += "\nПовторяется: (" + interval + ") ";

                if (replayEveryday)
                {
                    SummaryProb += "каждый день.";
                }
                if (replayEveryweek)
                {
                    SummaryProb += "каждую неделю (";

                    dayOfweek_map.Sort();

                    foreach (DayOfWeek _day in dayOfweek_map)
                    {
                        SummaryProb += culture.DateTimeFormat.GetDayName(_day) + " ";
                    }

                    SummaryProb += ")";
                }
                if (replayEverymonth)
                {
                    SummaryProb += "каждый месяц. ";
                }
                if (replayEveryyear)
                {
                    SummaryProb += "каждый год. ";
                }
                if (replayOther)
                {
                    SummaryProb += "каждые " + interval;
                }

                if (endingNever)
                {
                    SummaryProb += "\nдо бесконечности";
                }
                if (endingCount)
                {
                    SummaryProb += "\n" + countReplays + " раз";
                }
                if (endingDate)
                {
                    SummaryProb += "\nдо " + endDateTime.ToShortDateString();
                }
            }
        }

        /// <summary>
        /// ПРОВЕРКА НАСТУПЛЕНИЯ СОБЫТИЯ
        /// </summary>
        /// <param name="_end_task">ref признак окончания повторения</param>
        /// <param name="_executeDateTime">ref дата исполнения</param>
        /// <returns>признак срабатывания</returns>
        public bool EventChange(ref bool? _end_task, out DateTime _executeDateTime)
        {
            bool value = false;
            _end_task = false;
            _executeDateTime = StartDateTime;

            if (DateTime.Now >= StartDateTime)
            {
                if (!replay)
                {
                    value = true;
                    _end_task = true;
                }
                else
                {
                    #region проверка срока действия задания
                    if (endingNever) { _end_task = false; }
                    if (endingCount)
                    {
                        //countReplayMemory++;

                        //if (countReplayMemory >= countReplays)
                        //{
                        //    _end_task = true;
                        //}

                        countReplays--;

                        if (countReplays <= 0) { _end_task = true; }
                    }
                    if (endingDate)
                    {
                        if (DateTime.Now >= endDateTime)
                        {
                            _end_task = true;
                        }
                    }
                    #endregion

                    #region расчет следующей даты срабатывания
                    if (replayEveryweek)
                    {
                        if (dayOfweek_map.Exists(x => x == DateTime.Now.DayOfWeek))
                        {
                            value = true;
                        }
                        CalcIntervalWeek();
                        SetNextDateTime();
                    }
                    else
                    {
                        SetNextDateTime();
                        value = true;
                    }
                    #endregion
                }
            }

            return value;
        }
        #endregion

    }

    /// <summary>
    /// Проверка действительности.
    /// </summary>
    public class ProblemsValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            Problem problems = (value as BindingGroup).Items[0] as Problem;

            if (problems.MessageText == string.Empty)
            {
                return new ValidationResult(false, "Property Subject empty!");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}