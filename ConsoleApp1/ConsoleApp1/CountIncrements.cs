using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class CountIncrements
    {
        public static void PrintResult()
        {
            for (int increment = 1; increment <= 4; increment++)
            {
                for (int i = 0; i <= 24; i += increment)
                {
                    Console.Write(i != 0 ? $", {i}" : i.ToString());
                }
                Console.WriteLine(); 
            }
        }
    }
}
