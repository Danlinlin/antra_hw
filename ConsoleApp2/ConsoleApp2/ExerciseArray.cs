using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class ExerciseArray
    {
        public static void CopyArray()
        {
            int[] originalArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] copiedArray = new int[originalArray.Length];
            for (int i = 0; i < originalArray.Length; i++)
            {
                copiedArray[i] = originalArray[i];
            }

            Console.WriteLine("Original array:");
            foreach (int value in originalArray)
            {
                Console.Write(value + " ");
            }

            Console.WriteLine(); 
            Console.WriteLine("Copied array:");
            foreach (int value in copiedArray)
            {
                Console.Write(value + " ");
            }
        }

        public static void ListManager()
        {
            var items = new List<string>();
            string input;
            Console.WriteLine("List Manager");
            Console.WriteLine("Enter command (+ item, - item, or -- to clear):");

            do
            {
                input = Console.ReadLine().Trim();

                if (input.StartsWith("+ "))
                {
                    items.Add(input.Substring(2));
                    Console.WriteLine($"Added: {input.Substring(2)}");
                }
                else if (input.StartsWith("- "))
                {
                    string itemToRemove = input.Substring(2);
                    if (items.Remove(itemToRemove))
                    {
                        Console.WriteLine($"Removed: {itemToRemove}");
                    }
                    else
                    {
                        Console.WriteLine($"Item not found: {itemToRemove}");
                    }
                }
                else if (input == "--")
                {
                    items.Clear();
                    Console.WriteLine("All items cleared.");
                }
                else
                {
                    Console.WriteLine("Invalid command. Please use + or - followed by item, or -- to clear all items.");
                    continue;
                }

                Console.WriteLine("Current list:");
                foreach (var item in items)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Enter command (+ item, - item, or -- to clear):");

            } while (true); 
        }

        public static int[] FindNumber(int startNum, int endNum)
        {
            List<int> primesList = new List<int>();

            for (int num = startNum; num <= endNum; num++)
            {
                if (IsTarget(num))
                {
                    primesList.Add(num);
                }
            }

            return primesList.ToArray();
        }

        static bool IsTarget(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        public static void FindLongestSeq()
        {
            Console.WriteLine("Enter the array elements separated by space:");
            string input = Console.ReadLine();
            int[] inputArray = input.Split(' ').Select(int.Parse).ToArray();

            int longestSeLen = 1;
            int longestSeqNum = inputArray[0];
            int curSeqLen = 1;

            for (int i = 1; i < inputArray.Length; i++)
            {
                if (inputArray[i] == inputArray[i - 1])
                {
                    curSeqLen++;
                    if (curSeqLen > longestSeLen)
                    {
                        longestSeLen = curSeqLen;
                        longestSeqNum = inputArray[i];
                    }
                }
                else
                {
                    curSeqLen = 1;
                }
            }

            for (int i = 0; i < longestSeLen; i++)
            {
                Console.Write(longestSeqNum + " ");
            }
        }

        public static void FindMostFreqNum()
        {
            Console.WriteLine("Enter the sequence of numbers separated by space:");
            string input = Console.ReadLine();
            int[] numbers = input.Split(' ').Select(int.Parse).ToArray();

            var numFreq = new Dictionary<int, int>();
            foreach (var number in numbers)
            {
                if (numFreq.ContainsKey(number))
                {
                    numFreq[number]++;
                }
                else
                {
                    numFreq[number] = 1;
                }
            }

            int maxFrequency = numFreq.Values.Max();
            var mostFreqNum = numFreq.Where(pair => pair.Value == maxFrequency)
                                                       .Select(pair => pair.Key)
                                                       .OrderBy(n => Array.IndexOf(numbers, n)) // Order by first occurrence
                                                       .ToArray();

            if (mostFreqNum.Length == 1)
            {
                Console.WriteLine($"The number {mostFreqNum[0]} is the most frequent (occurs {maxFrequency} times)");
            }
            else
            {
                Console.WriteLine($"The numbers {string.Join(", ", mostFreqNum)} have the same maximal frequency (each occurs {maxFrequency} times). The leftmost of them is {mostFreqNum[0]}.");
            }
        }
    }

}
