using System;
using System.Numerics; 

namespace ConsoleApp1
{
    internal class TimeConversion
    {
        public static void ConvertCenturies()
        {
            Console.Write("Enter the number of centuries: ");
            int centuries = int.Parse(Console.ReadLine());

            const int YearsPerCentury = 100;
            const int DaysPerYear = 365; 
            const int DaysPerLeapYear = 366;
            const int HoursPerDay = 24;
            const int MinutesPerHour = 60;
            const int SecondsPerMinute = 60;
            const long MillisecondsPerSecond = 1000;
            const long MicrosecondsPerMillisecond = 1000;
            const long NanosecondsPerMicrosecond = 1000;

            int years = centuries * YearsPerCentury;
            int leapYears = centuries * 25;
            long days = (years * DaysPerYear) + leapYears; 
            long hours = days * HoursPerDay;
            long minutes = hours * MinutesPerHour;
            long seconds = minutes * SecondsPerMinute;
            BigInteger milliseconds = seconds * MillisecondsPerSecond;
            BigInteger microseconds = milliseconds * MicrosecondsPerMillisecond;
            BigInteger nanoseconds = microseconds * NanosecondsPerMicrosecond;

            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");
        }

    }
}
