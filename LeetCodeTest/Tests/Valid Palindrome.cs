using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCodeTest.Tests
{
    /// <summary>
    /// Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.
    /// Note: For the purpose of this problem, we define empty string as valid palindrome.
    /// </summary>
    class Valid_Palindrome : ISolution, IEasy, IComplete
    {
        public string Method()
        {
            var s = //"A man, a plan, a canal: Panama";
                    "0P";
            return IsPalindrome(s).ToString();
        }

        public bool IsPalindrome(string s)
        {
            var list = new List<char>();
            foreach (var ch in s.ToLower())
            {
                if (Char.IsLetterOrDigit(ch))
                    list.Add(ch);
            }

            var quotient = list.Count / 2;
            for (int i = 0; i < quotient; i++)
            {
                if (list.ElementAt(i) != list.ElementAt(list.Count - 1 - i))
                    return false;
            }
            return true;
        }
    }
}
