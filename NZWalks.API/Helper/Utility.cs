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
            bool result = true;

            foreach (var chr in inputArray)
            {
                if (chr < 48 || chr > 57)
                {
                    result = false;
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
    }
}
