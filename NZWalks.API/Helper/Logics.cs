namespace NZWalks.API.Helper
{
    public static class Logics
    {
        public static int RomanToInt(String s) 
        {
            Dictionary<string, int> romanDic = new Dictionary<string, int>
            {
                { "I", 1 },
                { "V", 5 },
                { "X", 10 },
                { "L", 50 },
                { "C", 100 },
                { "M", 1000 },
                { "IV", 4 },
                { "IX", 9 },
                { "XL", 40 },
                { "XC", 90 },
                { "CD", 400 },
                { "CM", 900 }
            };
            int result = 0;
            char previousCharacter = Char.MinValue;
           
            char[] newArray = s.ToCharArray();
            foreach (char currentCharacter in newArray)
            {
                if (previousCharacter == Char.MinValue 
                    || romanDic[previousCharacter.ToString()] >= romanDic[currentCharacter.ToString()])
                {
                    result += romanDic[currentCharacter.ToString()];
                }
                else  
                {
                    var newChar = previousCharacter.ToString() + currentCharacter.ToString();
                    result -= romanDic[previousCharacter.ToString()];
                    result += romanDic[newChar];
                }
                previousCharacter = currentCharacter;
            }
            return result;
        }

        public static int RomanToIntUsingReverse(String s)
        {
            Dictionary<char, int> romanDic = new Dictionary<char, int>
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };
            int result = 0;
            int previousCharValue = 0;

            char[] newArray = s.ToCharArray();
            for (int i = newArray.Length - 1; i >= 0; i--)
            {
                var currentCharValue = romanDic[newArray[i]];
                if (currentCharValue < previousCharValue)
                {
                    result -= currentCharValue;
                }
                else 
                {
                    result += currentCharValue;
                }
                previousCharValue = currentCharValue;
            }
            return result;
        }
    }
}
