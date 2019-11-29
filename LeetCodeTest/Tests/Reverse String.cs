using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCodeTest.Tests
{
    /// <summary>
    /// Write a function that reverses a string. The input string is given as an array of characters char[].
    /// 
    /// Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.
    /// 
    /// You may assume all the characters consist of printable ascii characters.
    /// </summary>
    class Reverse_String : ISolution, IEasy, IComplete
    {
        public string Method()
        {
            var s = new char[] { 'h', 'e', 'l', 'l', 'o' };
            ReverseString(s);
            return string.Concat(s);
        }

        public void ReverseString(char[] s)
        {
            var quotient = s.Length / 2;
            for (int i = 0; i < quotient; i++)
            {
                var top = s[i];
                var lastIndex = s.Length - 1 - i;
                var end = s[lastIndex];
                s[i] = end;
                s[lastIndex] = top;
            }
        }
    }
}
