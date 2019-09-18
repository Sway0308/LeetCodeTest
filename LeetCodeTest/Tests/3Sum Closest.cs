using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCodeTest.Tests
{
    /// <summary>
    /// Given an array nums of n integers and an integer target, 
    /// find three integers in nums such that the sum is closest to target. 
    /// Return the sum of the three integers. You may assume that each input would have exactly one solution.
    /// </summary>
    class _3Sum_Closest : ISolution
    {
        public string Method()
        {
            //var nums = new int[] { -17, -12, -28, 77, -28, -63, -88, 40, 70, -97, -57, 15, 45, 37, -85, -74, 29, -80, 92, -62, 44, 26, -46, 54, 74, 11, 16, -64, -58, 56, 23, -77, 48, 7, -44, 92, -25, 85, -16, -87, 22, 52, 57, 66, 83, -90, 84, -56, -54, -2, -98, -52, 78, 93, 7, 49, -10, -34, 49, -14, 87, -69, 1, -67, 53, -85, 29, -4, -39, 66, 8, 42, -48, -18, -41, 94, -1, 64, 52, 90, 32, 53, -10, 0, -86, -94, -13, 45, 43, -23, 61, -78, -44, -30, -3, 32, 94, 30, 74, 51, 63, -87, 46, 3, 61, -39, 9, 50, -23, 82, -100, -95, -31, -62, 88, -98, 22, 93, -81, 57, -56, 96, 78, -51, 24, -59, -80, 82, 77, 48, 88, -81, -61, 44, -1, -15, 62, -89, 21, -72, -4, -1, -84, 61, -59, -91, -87, 23, -9, -55, 34, 34, -13, 68, -95, -80, -36, -49, 97, 80, -50, -35, -6, -16, 91, 59, 74, 53, -48, -55, -25, -74, 81, -47, -98, -66, -62, -83, 24, -16, -35, 38 };
            //var target = -132;
            var nums = new int[] { 1, 1, 1, 0 };
            var target = 100;
            //var nums = new int[] { -26, 84, -85, 2, 99, 42, -28, 16, -97, -59, 64, -67, -30, 18, -15, -11, -60, -79, 41, -29, 49, -33, 21, -8, -73, 6, -31, 31, -23, 82, -34, 12, 86, 38, -4, 99, 4, 63, -13, -42, -4, 89, 88, -30, 0, 15, 37, -95, -85, 15, 66, 8, 43, 95, -76, 75, -16, 48, 15, -82, 56, 83, 91, 81, -76, -29, 7, -77, -42, 39, -73, 29, 43, -60, 21, -5, -3, 1, 32, 34, -77, 49, 68, -1, -63, 93, -20, -57, -65, 53, 23, 96, 79, 87, -12, -18, 51, 39, -24, 27, 13, -55, -6, 28, 95, 91, -71, 77, 49, -26, -17, -83, 43, -86, 28, 20, 64, -6, 53, 40, 81, -30, -83, 67, -3, 25, 37, 54, 95, 14, 84, -96, 76, 15, 35, 41, -86, 33, 10, -32, 59, 100, 30, -9, 58, -80, 23, 20, 43, 93, 58, -26, 37, 44, -24, 27, 99, -46, -80, -85, -44, -45, -72, -32, 33, -24, 91, -67, 75, -40, 52, 49, 94, -10, 82, -76, -92, 58, 18, -43, 47, -75, -17, -30, -17, -57, 37, 51, -32, 69, 54, -71, -98, -74, -17, 99, 84, -67, 80, -24, -100, 98, 19, 99, -7, -98, -43, 73, -97, -21, 96, -44, 59 };
            //var target = -186;
            var ans = ThreeSumClosest2(nums, target);
            return ans.ToString();
        }

        public int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            var total = nums.Take(3).Sum();
            for (int i = 0; i < nums.Length; i++)
            {
                var a = nums[i];
                for (int j = i + 1; j < nums.Length; j++)
                {
                    var b = nums[j];
                    var ans = nums.Skip(j + 1)
                                  .Select(x => new { Value = x, Total = a + b + x, AbsDiff = Math.Abs((a + b + x) - target) })
                                  .OrderBy(x => x.AbsDiff);
                    var absMin = Math.Abs(total - target);
                    if (!ans.Any(x => x.AbsDiff <= absMin))
                        continue;

                    var minAns = ans.First();
                    if (absMin == minAns.AbsDiff)
                        total = (minAns.Total > total) ? minAns.Total : total;
                    else if (absMin > minAns.AbsDiff)
                        total = minAns.Total;
                }
            }
            return total;
        }

        public int ThreeSumClosest2(int[] nums, int target)
        {
            var diff = int.MaxValue;
            var sum = 0;
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 2; ++i)
            {
                var l = i + 1;
                var h = nums.Length - 1;
                while (l < h)
                {
                    var tempSum = nums[i] + nums[l] + nums[h];
                    var tempDiff = target - tempSum;
                    if (Math.Abs(tempDiff) < diff)
                    {
                        diff = Math.Abs(tempDiff);
                        sum = tempSum;
                    }
                    if (tempDiff > 0) ++l;
                    if (tempDiff < 0) --h;
                    if (tempDiff == 0) return sum;
                }
                while (i + 1 < nums.Length - 2 && nums[i + 1] == nums[i]) ++i;
            }
            return sum;
        }
    }
}
