using System.Net.Http.Headers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProperCalender;
internal class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine(DateRighter.GetProperDate(DateTime.Now));
        //Console.WriteLine(DateRighter.GetProperDate(29, 2, 2025));
        //Console.WriteLine(DateRighter.GetProperDate(28, 2, 2025));
        //Console.WriteLine(DateRighter.GetProperDate(27, 2, 2025));
        //Console.WriteLine(DateRighter.GetProperDate(30, 2, 2025));
        //Console.WriteLine(DateRighter.GetProperDate(31, 3, 2025));
        //Console.WriteLine(DateRighter.GetProperDate(11, 11, 2025));
        Console.WriteLine(DateRighter.GetProperDate(31, 12, 2025));
        Console.WriteLine(DateRighter.GetProperDate(31, 12, 2020));
        //Console.WriteLine(DateRighter.GetProperDate(30, 12, 2025));
        //Console.WriteLine(DateRighter.GetProperDate(25, 12, 2025));
        Console.WriteLine(DateRighter.GetProperDate(27, 2, 2020));
        Console.WriteLine(DateRighter.GetProperDate(28, 2, 2020));
        Console.WriteLine(DateRighter.GetProperDate(29, 2, 2020));
        Console.WriteLine(DateRighter.GetProperDate(30, 2, 2020));
        Console.WriteLine(DateRighter.GetProperDate(1, 3, 2020));
    }
}

class DateRighter
{
    private static void TurnTheMonth(ref int day, ref int month)
    {
        month++;
        day = day - 28;
    }

    public static string GetProperDate(DateTime date)
    {
        int day = date.Day;
        int month = date.Month;
        int daysInMonth = DateTime.DaysInMonth(date.Year, month);

        int addForLeapYear = 0;
        if (DateTime.IsLeapYear(date.Year)) addForLeapYear = 1;

        switch (month)
        {
            case 1:
                if (day > 28)
                {
                    TurnTheMonth(ref day, ref month);
                }
                break;
            case 2:
                day = day + 3;
                if (day > 25)
                {
                    TurnTheMonth(ref day, ref month);

                }
                break;
            case 3:
                day = day + 3 + addForLeapYear;
                if (day > 22)
                {
                    TurnTheMonth(ref day, ref month);

                }
                break;
            case 4:
                day = day + 6 + addForLeapYear;
                if (day > 20)
                {
                    TurnTheMonth(ref day, ref month);

                }
                break;
            case 5:
                day = day + 11 + addForLeapYear;
                if (day > 17)
                {
                    TurnTheMonth(ref day, ref month);

                }
                break;
            case 6:
                day = day + 13 + addForLeapYear;
                if (day > 15)
                {
                    TurnTheMonth(ref day, ref month);

                }
                break;
            case 7:
                day = day + 16 + addForLeapYear;
                if (day > 12)
                {
                    TurnTheMonth(ref day, ref month);

                }
                break;
            case 8:
                day = day + 19 + addForLeapYear;
                if (day > 9)
                {
                    TurnTheMonth(ref day, ref month);

                }
                break;
            case 9:
                day = day + 21 + addForLeapYear;
                if (day > 6)
                {
                    TurnTheMonth(ref day, ref month);

                }
                break;
            case 10:
                day = day + 24 + addForLeapYear;
                if (day > 4)
                {
                    TurnTheMonth(ref day, ref month);

                }
                break;
            case 11:
                day = day + 26 + addForLeapYear;
                if (day > 2)
                {
                    TurnTheMonth(ref day, ref month);

                }
                break;
            case 12:
                day = day + 26 + addForLeapYear;
                if (day > 2)
                {
                    TurnTheMonth(ref day, ref month);

                }
                break;
            default:
                break;
        }
        return $"{day}.{month}.{date.Year}";
    }
    public static string GetProperDate(int day, int month, int year)
    {
        day = Math.Clamp(day, 1, DateTime.DaysInMonth(year, month));
        int daysInMonth = DateTime.DaysInMonth(year, month);
        int addForLeapYear = 0;
        if (DateTime.IsLeapYear(year)) addForLeapYear = 1;

        switch (month)
        {
            case 1:
                if (day > 28)
                {
                    TurnTheMonth(ref day, ref month);
                }
                break;
            case 2:
                day = day + 3;
                if (day > 25)
                {
                    TurnTheMonth(ref day, ref month);

                }
                break;
            case 3:
                day = day + 3 + addForLeapYear;
                if (day > 22)
                {
                    TurnTheMonth(ref day, ref month);

                }
                break;
            case 4:
                day = day + 6 + addForLeapYear;
                if (day > 20)
                {
                    TurnTheMonth(ref day, ref month);

                }
                break;
            case 5:
                day = day + 11 + addForLeapYear;
                if (day > 17)
                {
                    TurnTheMonth(ref day, ref month);

                }
                break;
            case 6:
                day = day + 13 + addForLeapYear;
                if (day > 15)
                {
                    TurnTheMonth(ref day, ref month);

                }
                break;
            case 7:
                day = day + 16 + addForLeapYear;
                if (day > 12)
                {
                    TurnTheMonth(ref day, ref month);

                }
                break;
            case 8:
                day = day + 19 + addForLeapYear;
                if (day > 9)
                {
                    TurnTheMonth(ref day, ref month);

                }
                break;
            case 9:
                day = day + 21 + addForLeapYear;
                if (day > 6)
                {
                    TurnTheMonth(ref day, ref month);

                }
                break;
            case 10:
                day = day + 24 + addForLeapYear;
                if (day > 4)
                {
                    TurnTheMonth(ref day, ref month);

                }
                break;
            case 11:
                day = day + 26 + addForLeapYear;
                if (day > 2)
                {
                    TurnTheMonth(ref day, ref month);

                }
                break;
            case 12:
                day = day + 26 + addForLeapYear;
                if (day > 2)
                {
                    TurnTheMonth(ref day, ref month);

                }
                break;
            default:
                break;
        }
        return $"{day}.{month}.{year}";
    }
}


static class DateTimeExpensions
{
    static string ProperDate(this DateTime dateTime, DateTime date)
    {
        return DateRighter.GetProperDate(date);
    }
}