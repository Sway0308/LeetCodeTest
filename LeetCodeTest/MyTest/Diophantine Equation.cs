using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeTest.Tests
{
    class Diophantine_Equation : ISolution
    {
        public string Method()
        {
            return solEquaStr(90005).ToString();
        }

        string solEquaStr(long n)
        {
            var x = new Queue<string>();
            long mid = (n + 1) / 2;
            var isExist = false;
            for (long i = mid; i >= 0; i--)
            {
                for (long j = mid; j >= 0; j--)
                {
                    if ((i - 2 * j) * (i + 2 * j) == n)
                    {
                        x.Enqueue((isExist ? ", " : "") + $"[{i}, {j}]");
                        isExist = true;
                        break;
                    }
                }
            }

            return $"[{string.Join("", x)}]";
        }
    }
}
