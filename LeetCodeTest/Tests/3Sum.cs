using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCodeTest
{
    /// <summary>
    /// Given an array nums of n integers, are there elements a, b, c in nums such that a + b + c = 0? Find all unique triplets in the array which gives the sum of zero.
    /// </summary>
    class _3Sum : ISolution
    {
        public string Method()
        {
            //var nums = new int[] { 14, -11, -2, -3, 4, -3, -3, -8, -15, 11, 11, -6, -14, -13, 5, -10, -13, 0, -12, -8, 14, -12, -10, 2, -4, 9, 13, 10, 2, 7, -2, -7, 4, 11, 5, -7, -15, 10, -7, -14, 6, 11, -5, 7, 6, 8, 5, 8, -7, 8, -15, 14, 11, 13, 1, -15, 7, 0, 10, -14, 14, -15, -14, 3, 4, 6, 4, 4, -7, 12, 5, 14, 0, 8, 7, 13, 1, -11, -2, 9, 12, -1, 8, 0, -11, -5, 0, 11, 2, -13, 4, 1, -12, 5, -10, -1, -12, 9, -12, -11, -2, 9, -12, 5, -6, 2, 4, 10, 6, -13, 4, 3, -7, -11, 11, -3, -9, -4, -15, 8, -9, -4, -13, -14, 8, 14 };
            var nums = new int[] { 7, -1, 14, -12, -8, 7, 2, -15, 8, 8, -8, -14, -4, -5, 7, 9, 11, -4, -15, -6, 1, -14, 4, 3, 10, -5, 2, 1, 6, 11, 2, -2, -5, -7, -6, 2, -15, 11, -6, 8, -4, 2, 1, -1, 4, -6, -15, 1, 5, -15, 10, 14, 9, -8, -6, 4, -6, 11, 12, -15, 7, -1, -9, 9, -1, 0, -4, -1, -12, -2, 14, -9, 7, 0, -3, -4, 1, -2, 12, 14, -10, 0, 5, 14, -1, 14, 3, 8, 10, -8, 8, -5, -2, 6, -11, 12, 13, -7, -12, 8, 6, -13, 14, -2, -5, -11, 1, 3, -6 };
            var ans = ThreeSum(nums);
            var text = "";
            foreach (var a in ans)
            {
                text += string.Join(",", a) + Environment.NewLine;
            }
            return text;
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            var result = new List<IList<int>>();
            var check = result.Select(x => x);
            for (int i = 0; i < nums.Length; i++)
            {
                var a = nums[i];
                for (int j = i + 1; j < nums.Length; j++)
                {
                    var b = nums[j];

                    if (a == b && check.Any(x => x.Where(y => y == a).Count() >= 2))
                        continue;
                    else if (a != b && check.Any(x => x.Contains(b) && x.Contains(a)))
                        continue;

                    var firstAns = a + b;
                    var diff = 0 - firstAns;
                    var secondAns = nums.Skip(j + 1).Where(x => x == diff).Distinct();

                    for (int k = 0; k < secondAns.Count(); k++)
                    {
                        result.Add(new List<int> { a, b, secondAns.ElementAt(k) });
                    }                    
                }
            }
            return result;
        }
    }
}
