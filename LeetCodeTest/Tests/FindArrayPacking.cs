using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeTest.Tests
{
    class FindArrayPacking : ISolution
    {
        public string Method()
        {
            return arrayPacking(new List<int> { 30, 29, 18, 44 }).ToString();
        }

        static int arrayPacking(List<int> a)
        {
            int result = 0;
            for (int index = 0; index < a.Count; index++)
            {
                if (a[index] > 256 || a[index] < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    result += a[index] << 8 * index;
                }
            }
            return result;
        }
    }
}
