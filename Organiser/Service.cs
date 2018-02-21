using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Organiser;

public static class SerializeA
{

    // сериализация
    public static void Serializes(object obj, string file_name)
    {
        var formter = new BinaryFormatter();

        using (FileStream fs = new FileStream(file_name + ".dat", FileMode.OpenOrCreate))
        {
            formter.Serialize(fs, obj);
        }
    }
        
    // десериализация
    public static object Deserializes(string file_name, object Object)
    {
        object obj;
        var formter = new BinaryFormatter();
        try
        {
            using (FileStream fs = new FileStream(file_name + ".dat", FileMode.OpenOrCreate))
            {
                obj = formter.Deserialize(fs);
            }
        }
        catch (Exception)
        {
            //System.Windows.MessageBox.Show(ex.Message);
            obj = Object;
        }

        return obj;
    }
}

/// <summary>
/// Сервисные методы
/// </summary>
public static class ServiceMain
{
    public static DateTime DateTimeFloor(DateTime _dt, TimePeriodType _tpt)
    {
        DateTime value = _dt;

        switch (_tpt)
        {
            case TimePeriodType._year:
                value = new DateTime(_dt.Year, 1, 1, 0, 0, 0);
                break;
            case TimePeriodType._month:
                value = new DateTime(_dt.Year, _dt.Month, 1, 0, 0, 0);
                break;
            case TimePeriodType._day:
                value = new DateTime(_dt.Year, _dt.Month, _dt.Day, 0, 0, 0);
                break;
            case TimePeriodType._hour:
                value = new DateTime(_dt.Year, _dt.Month, _dt.Day, _dt.Hour, 0, 0);
                break;
            case TimePeriodType._minute:
                value = new DateTime(_dt.Year, _dt.Month, _dt.Day, _dt.Hour, _dt.Minute, 0);
                break;
            case TimePeriodType._second:
                value = new DateTime(_dt.Year, _dt.Month, _dt.Day, _dt.Hour, _dt.Minute, _dt.Second);
                break;
            default:
                break;
        }

        return value;
    }
}
