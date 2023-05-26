using System.Linq;

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
        public static int RemoveDuplicates_UsingList(ref int[] nums)
        {
            List<int> templist = new List<int>();
            int previousValue = nums[0];
            templist.Add(previousValue);
            int k = 1;
            for (int i = 0; i <= nums.Length - 1; i++)
            {
                if (previousValue != nums[i])
                {
                    templist.Add(nums[i]);
                    previousValue = nums[i];
                    k++;
                }
            }
            // Loop on list to update nums

            for (int i = 0; i <= templist.Count - 1; i++)
            {
                nums[i] = templist[i];
            }
            return k;
        }

        public static int RemoveDuplicates(ref int[] nums)
        {
            int k = 0;
            for (int i = 1; i <= nums.Length - 1; i++)
            {
                if (nums[k] != nums[i])
                {
                    nums[++k] = nums[i];
                }
            }
            return k + 1;
        }

        public static string LongestSubString(string[] str)
        {
            //str = "Pankaj""Divya"
            //In this line s is a variable = 
            string s = str[0];
            string s1 = str[str.Length - 1]; ;
            string store = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == s1[i])
                {
                    store += s[i];
                }
            }
            return store;
        }

        public static bool IsValidStringWithBrackets(string s)
        {
            char[] chars = s.ToCharArray();
            bool isValidString = true;
            List<char> openingBrackets = new List<char>() { '(', '{', '[' };
            List<char> closingBrackets = new List<char> { ')', '}', ']' };
            Stack<char> stringBrackets = new Stack<char>();
            foreach (var chr in chars)
            {
                // if opening bracket
                if (openingBrackets.Contains(chr))
                {
                    // add in stringBrackets
                    stringBrackets.Push(chr);

                }
                // if closing bracket
                // if last item in stringBrackets is same pair opening
                // then remove from stringBrackets
                // invalid, hence set isValidString as false
                else if (closingBrackets.Contains(chr))
                {
                    // Case 1: stringBrackets is empty
                    if (stringBrackets.Count == 0)
                    {
                        isValidString = false;
                        break;
                    }

                    // Case 2: stringBrackets have some values
                    else
                    {
                        var difference = Math.Abs(chr - stringBrackets.Peek());
                        if (difference < 3)
                        {
                            stringBrackets.Pop();
                        }
                        else
                        {
                            isValidString = false;
                            break;
                        }
                    }
                }
            }

            return isValidString && (stringBrackets.Count == 0);
        }

        public static bool IsValidStringWithBrackets_Optimised(string s)
        {
            // Get ready initial state (enforce element type)
            var k = new Stack<char>();
            // Evaluate each character for potential mismatch 
            foreach (char c in s)
            {
                // Push closing round bracket onto the stack
                if (c == '(') { k.Push(')'); continue; }
                // Push closing curly bracket onto the stack
                if (c == '{') { k.Push('}'); continue; }
                // Push closing square bracket onto the stack
                if (c == '[') { k.Push(']'); continue; }
                // Look out for imbalanced strings or mismatches
                if (k.Count == 0 || c != k.Pop()) return false;
            }
            // Empty stack means string is valid and invalid otherwise
            return k.Count == 0;
        }
    }
}
