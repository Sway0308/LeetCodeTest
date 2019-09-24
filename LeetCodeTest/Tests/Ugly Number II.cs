using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCodeTest.Tests
{
    /// <summary>
    /// Write a program to find the n-th ugly number.
    /// Ugly numbers are positive numbers whose prime factors only include 2, 3, 5. 
    /// </summary>
    class Ugly_Number_II : ISolution
    {
        public string Method()
        {
            var n = //10;
                    //11;
                    //12;
                    //1;
                    //435;
                    437;
            return NthUglyNumber(n).ToString();
        }

        public int NthUglyNumber(int n)
        {
            if (n == 1) return 1;

            int resultIndex = 1;
            // 2, 3, 5
            var result = new int[n];
            var primes = new int[3] { 2, 3, 5 };
            var indexes = new int[3];
            result[0] = 1;
            while (resultIndex < n)
            {
                var min = int.MaxValue;

                var tempResult = new int[3];
                for (int i = 0; i < primes.Length; i++)
                {
                    tempResult[i] = primes[i] * result[indexes[i]];
                    min = Math.Min(min, tempResult[i]);
                }

                for (int i = 0; i < primes.Length; i++)
                {
                    if (tempResult[i] == min)
                    {
                        indexes[i]++;
                    }
                }

                result[resultIndex] = min;

                resultIndex++;
            }

            return result[n - 1];
        }

        public int NthUglyNumber2(int n)
        {
            var result = new List<int> { 1 };
            var i = 2;
            while (result.Count < n)
            {
                if (IsUglyNumber(i))
                    result.Add(i);
                i++;
            }
            return result.Last();
        }

        private bool IsUglyNumber(int n)
        {
            if (n == 1 || n == 2 || n == 3 || n == 5)
                return true;

            var a = n / 2;
            var b = n / 3;
            var c = n / 5;
            if (2 * a + 3 * b + 5 * c == n)
                return true;
            else if (2 * a + 3 * b == n)
                return true;
            else if (2 * a + 5 * c == n)
                return true;
            else if (3 * b + 5 * c == n)
                return true;
            else if (2 * a == n)
                return IsUglyNumber(a);
            else if (3 * b == n)
                return IsUglyNumber(b);
            else if (5 * c == n)
                return IsUglyNumber(c);
            return false;
        }
    }
}
