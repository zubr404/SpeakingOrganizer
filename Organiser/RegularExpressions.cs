using System;
using System.Text.RegularExpressions;
using Organiser;

static class RegularExpressionsMain
{
    public const string patternRu = @"\p{IsCyrillic}|\W";      // ищет русские буквы или любой символ(не цифра и не буква)
    public const string patternNum = @"\d";                 // ищет цифры
    public const string patternNoNum = @"\D";               // ищет все кроме цифр
    public const string patternNumOrTwoPoints = @"\d|:";    // ищет цифры или двоеточие

    public const string patternLeftClock = @"\d+:";          // левая часть часов
    public const string patternRightClock = @":\d+";         // правая часть часов
    public const string patternClock = @"\b[0-2][0-9]:[0-5][0-9]\b";     // ЧЧ:ММ (на границе слова)

    public const string patternData = @"\b[0-3][0-9].[0-1][0-9].[1-9][0-9][0-9][0-9]\b";     // ДД.ММ.ГГГГ (на границе слова)
    public const string patternNumOrPoints = @"\d+|\.";    // ищет цифры или точку

    // возвращает Истина, если нашел
    public static bool Search(string pattern, string expression)
    {
        Regex regex = new Regex( pattern, RegexOptions.IgnoreCase );
        MatchCollection matches = regex.Matches( expression );

        foreach(Match mat in matches)
        {

        }

        if (matches.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}