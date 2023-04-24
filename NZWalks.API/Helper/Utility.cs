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
    }
}
