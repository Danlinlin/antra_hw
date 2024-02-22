using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ReverseArray
{
    public static int[] GenerateNumbers(int length)
    {
        int[] numbers = new int[length];
        for (int i = 0; i < length; i++)
        {
            numbers[i] = i + 1;
        }
        return numbers;
    }

    public static void Reverse(int[] array)
    {
        int temp;
        for (int i = 0; i < array.Length / 2; i++)
        {
            temp = array[i];
            array[i] = array[array.Length - i - 1];
            array[array.Length - i - 1] = temp;
        }
    }

    public static void PrintNumbers(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + (i < array.Length - 1 ? ", " : ""));
        }
        Console.WriteLine();
    }
}
