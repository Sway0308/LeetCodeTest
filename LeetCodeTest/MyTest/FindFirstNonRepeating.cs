using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCodeTest.Tests
{
    /// <summary>
    /// Given a string, find its first non-repeating character
    /// </summary>
    class FindFirstNonRepeating : ISolution, IComplete
    {
        public string Method()
        {
            var ans = firstNonRepeating("sTASs");
            return ans;
        }

        string firstNonRepeating(string str)
        {
            var compareStr = str.ToLower();
            var arr = new int[256];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = -1;

            for (int i = 0; i < compareStr.Length; i++)
            {
                var a = compareStr[i];
                if (arr[a] == -1)
                    arr[a] = i;
                else
                    arr[a] = -2;
            }

            /*
            var b = arr.Where(x => x > 0).OrderBy(x => x);
            if (!b.Any())
                return "";
            else
                return str.Substring(b.First(), 1);
            */

            int res = int.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= 0)
                    res = Math.Min(res, arr[i]);
            }

            if (res == int.MaxValue)
                return "";
            return str.Substring(res, 1);
        }
    }
}
