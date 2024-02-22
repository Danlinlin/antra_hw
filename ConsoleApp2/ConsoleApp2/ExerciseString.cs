using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class ExerciseString
    {
        public static void ReverseString()
        {
            Console.WriteLine("Enter a string to reverse:");
            string input = Console.ReadLine();

            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            string reversed = new String(charArray);
            Console.WriteLine("Reversed using Array.Reverse: " + reversed);

            string reversedForLoop = "";
            for (int i = input.Length - 1; i >= 0; i--)
            {
                reversedForLoop += input[i];
            }
            Console.WriteLine("Reversed using for-loop: " + reversedForLoop);
        }

        public static void ReverseString2()
        {
            char[] separators = new char[] { '.', ',', ':', ';', '(', ')', '[', ']', '!', '?', ' ' };

            string sentence = "C# is not C++, and PHP is not Delphi!";

            string[] parts = Regex.Split(sentence, @"(\.|,|:|;|\(|\)|\[|\]|!|\?|\s)");
            Array.Reverse(parts);

            string reversedSentence = string.Concat(parts);
            Console.WriteLine(reversedSentence);
        }

        public static void PalindromesString()
        {
            string text = "Hi,exe? ABBA! Hog fully a string: EXE. Bob";

            var words = Regex.Matches(text, @"[\w]+")
                             .Cast<Match>()
                             .Select(m => m.Value)
                             .Distinct() // Remove duplicates
                             .Where(w => w.Equals(new string(w.Reverse().ToArray()), StringComparison.OrdinalIgnoreCase)) // Check if the word is a palindrome
                             .OrderBy(w => w) // Sort the words
                             .ToList();

            Console.WriteLine(String.Join(", ", words));
        }

        public static void ParseURL(string url, out string protocol, out string server, out string resource)
        {
            Uri uri;

            if (Uri.TryCreate(url, UriKind.Absolute, out uri))
            {
                protocol = uri.Scheme;
                server = uri.Host;
                resource = uri.AbsolutePath;
            }
            else
            {
                throw new ArgumentException("Invalid URL");
            }
        }
    }
}
