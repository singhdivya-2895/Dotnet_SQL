using System;
using System.Text.RegularExpressions;

namespace NZWalks.API.Helper
{
    public static class Utility
    {
        public static bool StringContainsNumeric(string inputString)
        {
            // Char[] inputArray = inputString.ToCharArray();
            //bool numericFound = false;
            //foreach (var chr in inputArray)
            //{
            //    if (chr >= 48 && chr <= 57)
            //    {
            //        numericFound = true;
            //        break;
            //    }
            //}
            //return numericFound;

            // return inputArray.Any(chr => chr >= 48 && chr <= 57);
            // return inputArray.Any(chr => int.TryParse(chr.ToString(), out _));
            return Regex.IsMatch(inputString, @"\d");
        }

        public static bool AllNumericString(String inputString)
        {
            char[] inputArray = inputString.ToCharArray();
            bool result = (inputArray.Length != 0);

            foreach (var chr in inputArray)
            {
                if (chr < 48 || chr > 57)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public static string UniqueCharacter(String inputString)
        {
            string uniqueChars = "";
            char[] myArray = inputString.ToCharArray();
            foreach (var chr in myArray)
            {
                if (!uniqueChars.Contains(chr))
                {
                    uniqueChars += chr;
                }
            }
            return uniqueChars;
        }
        //  mitin
        public static bool Palindrome(String inputString)
        {
            char [] myArray = inputString.ToCharArray();
            int middleNumber = myArray.Length/2;
            bool result = (myArray.Length != 0);

            for (int i = 0; i < middleNumber; i++)
            {
                if (myArray[i] != myArray[(myArray.Length-1) - i])
                {
                    result = false;
                    break;
                }
            } 
            return result;
        }
        public static bool NotPalindrome(String inputString)
        {
            char[] myArray = inputString.ToCharArray();
            int middleNumber = myArray.Length / 2;
            bool isNotaPalindrome = (myArray.Length != 0);
            for (int i = 0; i < middleNumber; i++)
            {
                if (myArray[i] == myArray[(myArray.Length - 1) - i])
                {
                    isNotaPalindrome = false;
                    break;
                }

            }
            return isNotaPalindrome;
        }

        public static string Reverse(String inputString)
        {
            char[] myArray = inputString.ToCharArray();
            char[] newArray = new char[myArray.Length];
            int maxIndex = myArray.Length - 1;

            for (int i = (maxIndex); i >= 0 ; i--)
            {
                newArray[maxIndex - i] = myArray[i];
            }
            return new string(newArray);
        }
    }
}
