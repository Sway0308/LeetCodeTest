using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCodeTest
{
    /// <summary>
    /// Write a function to find the longest common prefix string amongst an array of strings.
    /// If there is no common prefix, return an empty string "".
    /// </summary>
    class Longest_Common_Prefix : ISolution
    {
        public string Method()
        {
            var strs = new string[] {"acc", "aaa", "aaba"};
            return LongestCommonPrefix(strs);
        }

        public string LongestCommonPrefix(string[] strs)
        {
            if (!strs.Any())
                return "";
            if (strs.Length == 1)
                return strs[0];

            var minLen = strs.Min(x => x.Length);
            var minArrs = strs.Where(x => x.Length == minLen);
            var maxMinIndex = minLen - 1;
            for (int i = 0; i < strs.Length; i++)
            {
                var str = strs[i];
                foreach (var minStr in minArrs)
                {
                    if (minStr == str)
                    {
                        maxMinIndex = Math.Min(minStr.Length - 1, maxMinIndex);
                        continue;
                    }

                    for (int j = 0; j < minLen; j++)
                    {
                        if (str[j] == minStr[j])
                            continue;

                        maxMinIndex = Math.Min(j - 1, maxMinIndex);
                        break;
                    }
                }
            }
            return maxMinIndex < 0 ? "" : minArrs.First().Substring(0, maxMinIndex + 1);
        }
    }
}
