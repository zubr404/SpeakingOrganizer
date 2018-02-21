using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Linq;
using System.Windows.Media;
using ExtensionMethods;

namespace Organiser
{
    /// <summary>
    /// Типы временных периодов
    /// </summary>
    public enum TimePeriodType
    {
        _year,
        _month,
        _week,
        _day,
        _hour,
        _minute,
        _second
    }

    /// <summary>
    /// Представляет занятое/свободное время суммарно
    /// </summary>
    public class TimeSummary : BaseClass
    {
        private DateTime _dateStart;
        private DateTime _dateEnd;
        private double _width;
        private double _durationMinuteSum;
        private SolidColorBrush _color;
        private SolidColorBrush _colorForDate;

        // геометрические параметры интерфейса
        private double _width_interface;
        private double _ration_pixel_minute; // соотношение суммы минут в сутках к ширине в пикселях.

        #region -constructor-
        public TimeSummary(DateTime _datestart, DateTime _dateend)
        {
            _dateStart = _datestart;
            _dateEnd = _dateend;
            _width = 0;
            _durationMinuteSum = 0;
            ColorForDateSet();

            _width_interface = 350;
            _ration_pixel_minute = (24 * 60) / _width_interface;
        }
        #endregion

        #region -Properies-
        public DateTime DateStart
        {
            get { return _dateStart; }
            set
            {
                if (value != null)
                {
                    _dateStart = value;
                    base.NotifyPropertyChanged();
                }
            }
        }
        public DateTime DateEnd
        {
            get { return _dateEnd; }
            set
            {
                if (value != null)
                {
                    _dateEnd = value;
                    base.NotifyPropertyChanged();
                }
            }
        }
        public double WidthTS
        {
            get { return _width; }
            set
            {
                if (value >= 0)
                {
                    _width = value;
                    base.NotifyPropertyChanged();
                }
            }
        }
        public double DurationMinuteSum
        {
            get { return _durationMinuteSum; }
            set
            {
                if (value >= 0)
                {
                    _durationMinuteSum = value;
                    base.NotifyPropertyChanged();
                    ConvertToWidth();
                }
            }
        }
        public SolidColorBrush ColorTime
        {
            get { return _color; }
            set
            {
                if (value != null)
                {
                    _color = value;
                    base.NotifyPropertyChanged();
                }
            }
        }
        public SolidColorBrush ColorForDate
        {
            get { return _colorForDate; }
            set
            {
                if (value != null)
                {
                    _colorForDate = value;
                    base.NotifyPropertyChanged();
                }
            }
        }
        #endregion

        #region -Method-
        // конвертация суммы минут в ширину
        private void ConvertToWidth()
        {
            WidthTS = _durationMinuteSum / _ration_pixel_minute;
            EmploymentIndicator();
        }

        // цвета загруженности
        private void EmploymentIndicator()
        {
            double _ratio = _width / _width_interface;

            if (_ratio > 0 && _ratio < 0.5)
            {
                ColorTime = Brushes.DarkSeaGreen;
            }
            if (_ratio > 0.5 && _ratio < 0.75)
            {
                ColorTime = Brushes.Moccasin;
            }
            if (_ratio > 0.75 && _ratio < 0.85)
            {
                ColorTime = Brushes.LightSalmon;
            }
            if (_ratio > 0.85 && _ratio <= 1)
            {
                ColorTime = Brushes.LightCoral;
            }
            if (_ratio > 1)
            {
                ColorTime = Brushes.Red;
            }
        }

        // цвет шрифта для даты
        private void ColorForDateSet()
        {
            ColorForDate = Brushes.Black;

            if (_dateStart.DayOfWeek == DayOfWeek.Saturday | _dateStart.DayOfWeek == DayOfWeek.Sunday)
            {
                ColorForDate = Brushes.MediumSeaGreen;
            }
        }
        #endregion
    }

    /// <summary>
    /// Коллекция для TimeSummary
    /// </summary>
    public class TimeSummaryObservable : ObservableCollection<TimeSummary>
    {
        #region -конструктор-
        public TimeSummaryObservable(TimePeriodType _timePerType, DateTime _date)
        {
            switch (_timePerType)
            {
                case TimePeriodType._year:
                    break;
                case TimePeriodType._month:
                    break;
                case TimePeriodType._week:
                    break;
                case TimePeriodType._day:
                    DateTime _dtFloor = ServiceMain.DateTimeFloor(_date, TimePeriodType._month);

                    for (DateTime i = _dtFloor; i < _dtFloor.AddMonths(1); i = i.AddDays(1))
                    {
                        this.Add(new TimeSummary(i, i.AddDays(1)));
                    }
                    break;
                case TimePeriodType._hour:
                    break;
                case TimePeriodType._minute:
                    break;
                case TimePeriodType._second:
                    break;
                default:
                    break;
            }
        }
        #endregion

        //
        public void AddTimeSummary(ProblemObservable _problemObs, TimePeriodType _timePerType)
        {
            foreach (TimeSummary item in this)
            {
                item.DurationMinuteSum = 0;
            }

            switch (_timePerType)
            {
                case TimePeriodType._year:
                    break;
                case TimePeriodType._month:
                    break;
                case TimePeriodType._week:
                    break;
                case TimePeriodType._day:
                    
                    //foreach (Problem prob in _problemObs)
                    //{
                    //    TimeSummary _ts = this.FindMain(x => x.DateStart == ServiceMain.DateTimeFloor(prob.StartDateTime, TimePeriodType._day));

                    //    if (_ts != null)
                    //    {
                    //        _ts.DurationMinuteSum += prob.DurationProblem.TotalMinutes;
                    //    }
                    //}

                    CalcDurationSum(_problemObs);

                    break;
                case TimePeriodType._hour:
                    break;
                case TimePeriodType._minute:
                    break;
                case TimePeriodType._second:
                    break;
                default:
                    break;
            }
        }

        private void CalcDurationSum(ProblemObservable _problemObs)
        {
            foreach (TimeSummary tsum in this)
            {
                foreach (Problem prob in _problemObs)
                {
                    if (tsum.DateStart == ServiceMain.DateTimeFloor(prob.StartDateTime, TimePeriodType._day))
                    {
                        tsum.DurationMinuteSum += prob.DurationProblem.TotalMinutes;
                    }
                    else
                    {
                        if (tsum.DateStart > prob.StartDateTime)
                        {
                            if (prob.Replay)
                            {
                                DateTime _startDateTimeProb = prob.StartDateTime;

                                // каждый день
                                if (prob.ReplayEveryday)
                                {
                                    if (prob.EndingNever)
                                    {
                                        tsum.DurationMinuteSum += prob.DurationProblem.TotalMinutes;
                                    }
                                    if (prob.EndingCount)
                                    {
                                        // сделать метод умножения TimeSpan
                                        DateTime _endDateTimeProb = prob.StartDateTime.Add(TimeSpan.FromTicks(new TimeSpan(1,0,0,0).Ticks * (prob.CountReplays - 1)));

                                        if (_endDateTimeProb >= tsum.DateStart)
                                        {
                                            tsum.DurationMinuteSum += prob.DurationProblem.TotalMinutes;
                                        }
                                    }
                                    if (prob.EndingDate)
                                    {
                                        if (prob.EndDateTime >= tsum.DateStart)
                                        {
                                            tsum.DurationMinuteSum += prob.DurationProblem.TotalMinutes;
                                        }
                                    }
                                }

                                // каждую неделю
                                if (prob.ReplayEveryweek)
                                {
                                    if (prob.EndingNever)
                                    {
                                        if (prob.DayOfWeekList.Exists(x => x == tsum.DateStart.DayOfWeek))
                                        {
                                            tsum.DurationMinuteSum += prob.DurationProblem.TotalMinutes;
                                        }
                                    }
                                    if (prob.EndingCount)
                                    {
                                        for(int i = prob.CountReplays; i > 0;)
                                        {
                                            if (prob.DayOfWeekList.Exists(x => x == tsum.DateStart.DayOfWeek))
                                            {
                                                tsum.DurationMinuteSum += prob.DurationProblem.TotalMinutes;
                                                i--;
                                            }
                                        }
                                    }
                                    if (prob.EndingDate)
                                    {
                                        if (prob.EndDateTime >= tsum.DateStart)
                                        {
                                            if (prob.DayOfWeekList.Exists(x => x == tsum.DateStart.DayOfWeek))
                                            {
                                                tsum.DurationMinuteSum += prob.DurationProblem.TotalMinutes;
                                            }
                                        }
                                    }
                                }

                                // каждый месяц
                                if (prob.ReplayEverymonth)
                                {

                                }

                                // каждый год
                                if (prob.ReplaysEveryyear)
                                {

                                }
                                
                                // другой интервал
                                if (prob.ReplayOther)
                                {

                                }
                            }
                        }
                    }
                }
            }
        }
    }
}