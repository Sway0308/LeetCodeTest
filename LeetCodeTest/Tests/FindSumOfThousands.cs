using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeTest.Tests
{
    class FindSumOfThousands : ISolution
    {
        public string Method()
        {
            return SumOfThousands(9000).ToString();
        }

        int SumOfThousands(int num)
        {
            var a = num / 1000;
            var sum = 0;
            for (int i = 1; i <= a; i++)
            {
                sum += i;
            }
            return sum * 1000;
        }
    }
}
