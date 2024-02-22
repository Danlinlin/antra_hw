using System;

namespace ConsoleApp1
{
    internal class PrintAPyramid
    {
        public static void PrintIt()
        {
            int pyramidHeight = 5;
            for (int i = 0; i < pyramidHeight; i++)
            {
                for (int space = 0; space < pyramidHeight - i - 1; space++)
                {
                    Console.Write(" ");
                }
                for (int star = 0; star < (2 * i) + 1; star++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}

