using System;

namespace ConsoleApp1
{
    internal class _02UnderstandingTypes
    {
        public static void ShowTypeInfo()
        {
            Console.WriteLine("Type    | Bytes of memory | Min                             | Max");
            Console.WriteLine("--------|-----------------|---------------------------------|---------------------------------");
            PrintTypeInfo("sbyte", sizeof(sbyte), sbyte.MinValue, sbyte.MaxValue);
            PrintTypeInfo("byte", sizeof(byte), byte.MinValue, byte.MaxValue);
            PrintTypeInfo("short", sizeof(short), short.MinValue, short.MaxValue);
            PrintTypeInfo("ushort", sizeof(ushort), ushort.MinValue, ushort.MaxValue);
            PrintTypeInfo("int", sizeof(int), int.MinValue, int.MaxValue);
            PrintTypeInfo("uint", sizeof(uint), uint.MinValue, uint.MaxValue);
            PrintTypeInfo("long", sizeof(long), long.MinValue, long.MaxValue);
            PrintTypeInfo("ulong", sizeof(ulong), ulong.MinValue, ulong.MaxValue);
            PrintTypeInfo("float", sizeof(float), float.MinValue, float.MaxValue);
            PrintTypeInfo("double", sizeof(double), double.MinValue, double.MaxValue);
            PrintTypeInfo("decimal", sizeof(decimal), decimal.MinValue, decimal.MaxValue);
        }

        private static void PrintTypeInfo(string typeName, int bytesOfMemory, object minValue, object maxValue)
        {
            Console.WriteLine("{0,-7} | {1,15} | {2,32} | {3,32}", typeName, bytesOfMemory, minValue, maxValue);
        }
    }
}

