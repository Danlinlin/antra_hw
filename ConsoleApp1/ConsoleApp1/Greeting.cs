using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Greeting
    {
        public static void PrintGreeting()
        {
            TimeSpan morningStart = new TimeSpan(5, 0, 0); 
            TimeSpan afternoonStart = new TimeSpan(12, 0, 0); 
            TimeSpan eveningStart = new TimeSpan(17, 0, 0); 
            TimeSpan nightStart = new TimeSpan(22, 0, 0); 

            DateTime currentTime = DateTime.Now;
            if (currentTime.TimeOfDay >= nightStart || currentTime.TimeOfDay < morningStart)
            {
                Console.WriteLine("Good Night");
            }
            else if (currentTime.TimeOfDay >= eveningStart)
            {
                Console.WriteLine("Good Evening");
            }
            else if (currentTime.TimeOfDay >= afternoonStart)
            {
                Console.WriteLine("Good Afternoon");
            }
            else
            {
                Console.WriteLine("Good Morning");
            }
        }
    }
}
