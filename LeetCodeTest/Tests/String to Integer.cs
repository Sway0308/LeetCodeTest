using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeTest.Tests
{
    /// <summary>
    /// Implement atoi which converts a string to an integer.
    /// The function first discards as many whitespace characters as necessary until the first non-whitespace character is found.Then, 
    /// starting from this character, takes an optional initial plus or minus sign followed by as many numerical digits as possible, 
    /// and interprets them as a numerical value.
    /// The string can contain additional characters after those that form the integral number, which are ignored and have no effect on the behavior of this function.
    /// If the first sequence of non-whitespace characters in str is not a valid integral number, 
    /// or if no such sequence exists because either str is empty or it contains only whitespace characters, no conversion is performed.
    /// If no valid conversion could be performed, a zero value is returned.
    /// </summary>
    class String_to_Integer : ISolution
    {
        public string Method()
        {
            var str = "2147483648";
            var ans = MyAtoi(str);
            return ans.ToString();
        }

        public int MyAtoi(string str)
        {
            str = str.Trim();
            var ans = "";
            var isPositive = true;
            for (int i = 0; i < str.Length; i++)
            {
                var s = str[i].ToString();
                if (int.TryParse(s, out var val))
                    ans += val;
                else if (i == 0 && (s == "+" || s == "-"))
                    isPositive = (s != "-");
                else
                    break;                
            }
            var result = ans.Length == 0 ? 0 : (double.Parse(ans) * (isPositive ? 1 : -1));
            return result > int.MaxValue ? int.MaxValue : (result < int.MinValue ? int.MinValue : (int)result);
        }
    }
}
