using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCodeTest
{
    class Palindrome_Number : ISolution
    {
        public string Method()
        {
            var x = 2147483647;
            var ans = IsPalindrome(x);
            return ans.ToString();
        }


        public bool IsPalindrome(int x)
        {
            if (x < 0 || (x >= 10 && x % 10 ==0))
                return false;

            if (x < 10)
                return true;

            var dic = new List<int>();
            var value = x;
            var i = 1;
            while (value != 0)
            {
                var n = value % 10;
                dic.Add(n);
                i++;
                value /= 10;
            }

            var count = dic.Count;
            var midCount = count / 2;
            for (int j = 0; j < midCount; j++)
            {
                if (dic[j] != dic[count - j - 1])
                    return false;
            }
            return true;
        }
    }
}
