using System;
using Organiser;
using System.Windows.Threading;
using System.Speech.Synthesis;

public static class Speak
{
    #region -говорилка-
    public static void Speakmain (SpeechSynthesizer synthesizer, string message, bool speak_on, bool speek_all = false)
    {
        if (speak_on | speek_all)
        {
            synthesizer.SpeakAsync( message );
        }
    }
    public static void Speakmain(SpeechSynthesizer synthesizer, Problem prob, bool speak_on, bool speek_all = false)
    {
        if (speak_on | speek_all)
        {
            synthesizer.SpeakAsync( MsgSpeak(prob) );
        }
    }
    #endregion

    #region -sound-
    // передаем только имя файла
    public static void PlaySound(string _fileName, bool _play, DispatcherTimer pause_timer)
    {
        if (_play)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = System.IO.Directory.GetCurrentDirectory() + @"\Sound\" + _fileName;

            try
            {
                player.Load();
                player.Play();
            }
            catch (Exception)
            {

            }

            pause_timer.Start();
        }
    }

    // передаем полный путь к файлу .wav
    public static void PlaySoundDirectory(string _pathAll, bool _play, DispatcherTimer pause_timer)
    {
        if (_play)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = _pathAll;

            try
            {
                player.Load();
                player.Play();
            }
            catch (Exception)
            {

            }

            pause_timer.Start();
        }
    }

    //
    public static void PlaySoundTest(string _pathAll)
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        player.SoundLocation = _pathAll;

        try
        {
            player.Load();
            player.Play();
        }
        catch (Exception)
        {

        }
    }
    #endregion

    #region -Message box-
    public static void MessageWindow(string _message, bool _mesFlag)
    {
        MessageWindow mesWin;

        if (_mesFlag)
        {
            mesWin = new MessageWindow();
            mesWin.ShowActivated = true;
            mesWin.Show();
            mesWin.MessageSet(_message);
        }
    }
    #endregion

    #region -Чтение из файла-
    public static void SpeakFileText(SpeechSynthesizer synthesizer, string[] _strColl, int _index)
    {
        try
        {
            synthesizer.SpeakAsync(_strColl[_index]);
        }
        catch (Exception)
        {
           
        }
        
    }

    // загрузить текст
    public static string[] LoadText()
    {
        try
        {
            return System.IO.File.ReadAllLines(System.IO.Directory.GetCurrentDirectory() + @"\Text\Text1.txt");
        }
        catch (Exception)
        {
            return null;
        }
        
    }
    #endregion

    // готовим сообщение по всей строке
    private static string MsgSpeak( Problem prob )
    {
        string msg = string.Empty;

        //msg = "На сегодня, на " + TimeSpeakCorrecty(prob.TimeO, 1) + " назначено: " + prob.Problem + ".";

        return msg;
    }

    // список заданий до начала, которых осталось Interval
    public static System.Collections.Generic.IEnumerable<Problem> TaskOnTime( ProblemObservable prob_obser, TimeSpan Interval )
    {
        DateTime Data = new DateTime();

        Data = DateTime.Now;

        //var prob_first = from prob in prob_obser
        //                 where prob.DateO != string.Empty & prob.TimeO != string.Empty & prob.Problem != string.Empty
        //                 select prob;

        //var prob_ob = from prob in prob_first
        //              let DataTab = Convert.ToDateTime( prob.DateO + " " + prob.TimeO ).Subtract( Data )
        //              where DataTab < Interval & DataTab > new TimeSpan( 0, 0, 0 )
        //              orderby prob.TimeO ascending
        //              select prob;

        //return prob_ob;
        return null;
    }

    // список заданий за определенную дату
    public static System.Collections.Generic.IEnumerable<Problem> TaskOnData( ProblemObservable prob_obser, string data )
    {
        //var prob_ob = from prob in prob_obser
        //              where prob.DateO == data
        //              orderby prob.TimeO ascending
        //              select prob;

        //return prob_ob;
        return null;
    }


    // обработка сообщений по времени
    public static void TimeManagementProcessing( ProblemObservable prob_odser, TimeSpan Interval )
    {
        DateTime Data = new DateTime();
        //DateTime DataTab = new DateTime();
        TimeSpan SpanDay = new TimeSpan( 1, 0, 0, 0 );
        TimeSpan SpanWeek = new TimeSpan( 7, 0, 0, 0 );

        Data = DateTime.Now;

        //for (int i = 0; i < prob_odser.Count; i++)
        //{
        //    Problem pr = prob_odser[i];

        //    if (pr.DateO != null & pr.TimeO != null)
        //    {
        //        try
        //        {
        //            DataTab = Convert.ToDateTime( pr.DateO + " " + pr.TimeO );
        //        }
        //        catch (Exception)
        //        {
        //            DataTab = Convert.ToDateTime( "01.01.1900 00:00" );
        //        }


        //        if (DataTab.Subtract( Data ) < Interval)
        //        {
        //            if (!pr.Everyday & !pr.Everyweek)
        //            {
        //                prob_odser.RemoveAt( i );
        //                i--;
        //            }
        //            if (pr.Everyday)
        //            {
        //                pr.DateO = Convert.ToDateTime( pr.DateO ).AddDays( 1 ).ToShortDateString();
        //            }
        //            if (pr.Everyweek)
        //            {
        //                pr.DateO = Convert.ToDateTime( pr.DateO ).AddDays( 7 ).ToShortDateString();
        //            }
        //        }
        //    }
        //}
    }

    #region грамотно озвучиванм дату
    public static string DataCorrecty(DataDictionary data_dictionary, string data, int padech )
    {
        string correcty_data = string.Empty;

        int day = Convert.ToInt32( data.Substring( 0, 2 ) );
        int month = Convert.ToInt32( data.Substring( 3, 2 ) );
        int year = Convert.ToInt32( data.Substring( 6, 4 ) );

        switch (padech)
        {
            case 0:
                correcty_data = data_dictionary.day[day] + " " + data_dictionary.month[month];
                break;
            case 1:
                correcty_data = data_dictionary.day1[day] + " " + data_dictionary.month[month];
                break;
            default:
                break;
        }
        

        return correcty_data;
    }
    #endregion

    #region грамотно озвучиваем время
    public static string TimeSpeakCorrecty(string time, int padech)
    {
        string correcty_time = string.Empty;
        int len = time.Length;

        if (len != 5) 
        {
            return correcty_time;
        }

        if (time == "00:00")
        {
            correcty_time = "0 часов 0 минут";
            return correcty_time;
        }

        string HH = string.Empty;
        string MM = string.Empty;

        for (int i = 0; i < len; i++ )
        {
            string lit = time.Substring(i, 1);

            if (i < 2) 
            {
                if (i == 0 & lit != "0")
                {
                    HH += lit;
                }
                if (i == 1)
                {
                    HH += lit;
                }
            }

            if (i > 2) 
            {
                if (i == 3 & lit != "0")
                {
                    MM += lit;
                }
                if (i == 4)
                {
                    MM += lit;
                }
            }
        }

        correcty_time = HourSpeakCorrecty( HH ) + MinuteSpeakCorrecty( MM, padech );

        return correcty_time;
    }

    public static string HourSpeakCorrecty(string HH)
    {
        string correctyHH = string.Empty;

        if (HH.Length < 3)
        {
            correctyHH = HH + " часов ";

            // все НН оканчивающиеся на 1
            if (HH != "11")
            {
                if (HH.Substring( HH.Length - 1, 1 ) == "1")
                {
                    correctyHH = HH + " час ";
                }
            }

            // все НН оканчивающиеся на 2,3,4
            if (HH != "12" & HH != "13" & HH != "14")
            {
                string end_H = HH.Substring( HH.Length - 1, 1 );
                if (end_H == "2" | end_H == "3" | end_H == "4")
                {
                    correctyHH = HH + " часа ";
                }
            }
        }

        return correctyHH;
    }

    // если padesh = 0 - именительный падеж, или все остальное
    public static string MinuteSpeakCorrecty(string MM, int padesh)
    {
        string correctyMM = string.Empty;

        if (MM.Length < 3)
        {
            correctyMM = MM + " минут ";

            string end_M = MM.Substring( MM.Length - 1, 1 );

            // все MM оканчивающиеся на 1
            if (MM != "11")
            {
                if (end_M == "1")
                {
                    if (padesh == 0)
                    {
                        //correctyMM = MM + " минута "; // одна

                            MM = ((Convert.ToInt32( MM ) / 10) * 10).ToString();
                            if (MM == "0") { MM = string.Empty; }
                            correctyMM = MM + " одна минута ";

                    }
                    else
                    {
                        //correctyMM = MM + " минуту "; // одну

                        MM = ((Convert.ToInt32( MM ) / 10) * 10).ToString();
                        if (MM == "0") { MM = string.Empty; }
                        correctyMM = MM + " одну минуту ";
                    }
                }
            }

            // все НН оканчивающиеся на 2,3,4
            if (MM != "12" & MM != "13" & MM != "14")
            {
                if (end_M == "3" | end_M == "4")
                {
                    correctyMM = MM + " минуты ";
                }

                if (end_M == "2")
                {
                    MM = ((Convert.ToInt32( MM ) / 10) * 10).ToString();
                    if (MM == "0") { MM = string.Empty; }
                    correctyMM = MM + " две минуты ";
                }
            }
        }

        return correctyMM;
    }
    #endregion
}

public class DataDictionary
{
    public string[] day = new string[32];
    public string[] day1 = new string[32];

    public string[] month = new string[13];

    public DataDictionary()
    {
        day[0] = "нулевое";
        day[1] = "первое";
        day[2] = "второе";
        day[3] = "третье";
        day[4] = "четвертое";
        day[5] = "пятое";
        day[6] = "шестое";
        day[7] = "седьмое";
        day[8] = "восьмое";
        day[9] = "девятое";
        day[10] = "десятое";
        day[11] = "одинадцатое";
        day[12] = "двенадцатое";
        day[13] = "тринадцатое";
        day[14] = "четырнадцатое";
        day[15] = "пятнадцатое";
        day[16] = "шестнадцатое";
        day[17] = "семнадцатое";
        day[18] = "восемнадцатое";
        day[19] = "девятнадцатое";
        day[20] = "двадцатое";
        day[21] = "двадцать первое";
        day[22] = "двадцать второе";
        day[23] = "двадцать третье";
        day[24] = "двадцать четвертое";
        day[25] = "двадцать пятое";
        day[26] = "двадцать шестое";
        day[27] = "двадцать седьмое";
        day[28] = "двадцать восьмое";
        day[29] = "двадцать девятое";
        day[30] = "трицатое";
        day[31] = "тридцать первое";

        day1[0] = "нулевого";
        day1[1] = "первого";
        day1[2] = "второго";
        day1[3] = "третьего";
        day1[4] = "четвертого";
        day1[5] = "пятого";
        day1[6] = "шестого";
        day1[7] = "седьмого";
        day1[8] = "восьмого";
        day1[9] = "девятого";
        day1[10] = "десятого";
        day1[11] = "одинадцатого";
        day1[12] = "двенадцатого";
        day1[13] = "тринадцатого";
        day1[14] = "четырнадцатого";
        day1[15] = "пятнадцатого";
        day1[16] = "шестнадцатого";
        day1[17] = "семнадцатого";
        day1[18] = "восемнадцатого";
        day1[19] = "девятнадцатого";
        day1[20] = "двадцатого";
        day1[21] = "двадцать первого";
        day1[22] = "двадцать второго";
        day1[23] = "двадцать третьего";
        day1[24] = "двадцать четвертого";
        day1[25] = "двадцать пятого";
        day1[26] = "двадцать шестого";
        day1[27] = "двадцать седьмого";
        day1[28] = "двадцать восьмого";
        day1[29] = "двадцать девятого";
        day1[30] = "трицатого";
        day1[31] = "тридцать первого";

        month[0] = "нулября";
        month[1] = "января";
        month[2] = "февраля";
        month[3] = "марта";
        month[4] = "апреля";
        month[5] = "мая";
        month[6] = "июня";
        month[7] = "июля";
        month[8] = "августа";
        month[9] = "сентября";
        month[10] = "октября";
        month[11] = "ноября";
        month[12] = "декабря";
    }
}