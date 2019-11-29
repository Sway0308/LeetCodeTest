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
    class Ugly_Number_II : ISolution, IMedium, IComplete
    {
        public string Method()
        {
            var n = //10;
                    //11;
                    //12;
                    //1;
                    //435;
                    //437;
                    //451;
                    461;
            return NthUglyNumber(n).ToString();
        }

        public int NthUglyNumber(int n)
        {
            if (n == 1) return 1;

            int resultIndex = 1;
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
    }
}
