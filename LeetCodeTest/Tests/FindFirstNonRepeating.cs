using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeTest.Tests
{
    class FindFirstNonRepeating : ISolution
    {
        public string Method()
        {
            var ans = firstNonRepeating("sTreSs");
            return ans;
        }

        string firstNonRepeating(String str)
        {
            var compareStr = str.ToLower();
            var arr = new int[256];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = -1;

            for (int i = 0; i < compareStr.Length; i++)
            {
                if (arr[compareStr[i]] == -1)
                    arr[compareStr[i]] = i;
                else
                    arr[compareStr[i]] = -2;
            }

            int res = int.MaxValue;
            for (int i = 0; i < arr.Length; i++)

                // If this character occurs  
                // only once and appears before 
                // the current result, then  
                // update the result 
                if (arr[i] >= 0)
                    res = Math.Min(res, arr[i]);

            if (res == int.MaxValue)
                return "";
            return str.Substring(res, 1);
        }
    }
}
