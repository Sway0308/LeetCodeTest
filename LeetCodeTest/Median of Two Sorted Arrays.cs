using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCodeTest
{
    class Median_of_Two_Sorted_Arrays
    {
        public static void Main()
        {
            Console.WriteLine(DateTime.Now);
            Console.WriteLine(DateTime.Now);
            var a = new int[] { 1, 2 };
            var b = new int[] { 3, 4 };
            var ans = FindMedianSortedArrays(a, b);
            Console.WriteLine(ans);
            Console.ReadKey();
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var result = nums1.Concat(nums2).OrderBy(x => x);
            var count = result.Count();
            if (count % 2 == 0)
            {
                var a = count / 2;
                //var b = result.ElementAt(a - 1);
                //var c = result.ElementAt(a);
                return (result.ElementAt(a - 1) + result.ElementAt(a)) / 2.0;
            }
            else
            {
                var a = (int)Math.Floor(count / 2.0);
                return result.ElementAt(a);
            }
        }
    }
}
