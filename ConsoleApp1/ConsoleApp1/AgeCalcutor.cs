using System;

namespace ConsoleApp1
{
    internal class AgeCalculator
    {
        public static void PrintResult()
        {
            DateTime birthDate = new DateTime(1998, 2, 2); 
            DateTime currentDate = DateTime.Today;

            TimeSpan ageSpan = currentDate - birthDate;
            int daysOld = ageSpan.Days;
            Console.WriteLine($"You are {daysOld} days old.");

            int daysToNextAnniversary = 10000 - (daysOld % 10000);
            DateTime nextAnniversary = currentDate.AddDays(daysToNextAnniversary);
            Console.WriteLine($"Your next 10,000 day anniversary will be on: {nextAnniversary.ToShortDateString()}.");
        }
    }
}


