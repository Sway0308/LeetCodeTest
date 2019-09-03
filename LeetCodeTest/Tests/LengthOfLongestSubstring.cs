using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCodeTest
{
    /// <summary>
    /// Given a string, find the length of the longest substring without repeating characters.
    /// </summary>
    class LengthOfLongestSubstring : ISolution
    {
        public string Method()
        {
            var s = "abcdefghijklmnopqrstuvwxyzdef";
            var ans = CalcLengthOfLongestSubstring2(s);
            return ans.ToString();
        }

        public int CalcLengthOfLongestSubstring2(string s)
        {
            int max = 0;
            int i = 0;
            Queue<char> Q = new Queue<char>();
            while (i < s.Length)
            {
                var c = s[i];
                if (Q.Contains(c))
                {
                    while (Q.Peek() != s[i]) Q.Dequeue();
                    Q.Dequeue();
                }
                Q.Enqueue(c);
                max = Math.Max(max, Q.Count);
                i++;
            }
            return max;
        }
    }
}
