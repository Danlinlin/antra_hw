using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Exercise03
    {
        public static void FizzBuzzGame()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("fizzbuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static void CheckForByteOverflow()
        {
            int max = 500;
            for (byte i = 0; i < max; i++)
            {
                if (i == byte.MaxValue)
                {
                    Console.WriteLine($"Warning: 'i' has reached its maximum value {byte.MaxValue} and will overflow.");
                }
                Console.WriteLine(i);
            }
        }

        public static void GuessNumber()
        {

            int correctNumber = new Random().Next(3) + 1; 
            Console.Write("Guess the number (between 1 and 3): ");
            int guessedNumber = int.Parse(Console.ReadLine());

            if (guessedNumber < 1 || guessedNumber > 3)
            {
                Console.WriteLine("Your guess is out of the valid range. Please guess a number between 1 and 3.");
            }
            else if (guessedNumber < correctNumber)
            {
                Console.WriteLine("Your guess is too low.");
            }
            else if (guessedNumber > correctNumber)
            {
                Console.WriteLine("Your guess is too high.");
            }
            else
            {
                Console.WriteLine("Congratulations! You guessed the correct number.");
            }
        }

    }
}
