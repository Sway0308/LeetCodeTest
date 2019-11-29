using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeTest.Tests
{
    /// <summary>
    /// Write a program to check whether a given number is an ugly number.
    /// Ugly numbers are positive numbers whose prime factors only include 2, 3, 5.
    /// </summary>
    class Ugly_Number : ISolution, IEasy, IComplete
    {
        public string Method()
        {
            var num = //6;
                      //8;
                      //14;
                      //-2147483648;
                      -1000;
            var ans = IsUgly(num);
            return ans.ToString();
        }

        public bool IsUgly(int num)
        {
            if (num == 1) return true;
            if (num <= 0) return false;

            return CheckIsUgly(num);
        }

        private bool CheckIsUgly(int num)
        {
            while (num % 2 == 0 || num % 3 == 0 || num % 5 == 0)
            {
                if (num % 2 == 0) num /= 2;
                if (num % 3 == 0) num /= 3;
                if (num % 5 == 0) num /= 5;
            }

            return num == 1;
        }
    }
}
