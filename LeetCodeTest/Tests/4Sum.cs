using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCodeTest.Tests
{
    /// <summary>
    /// Given an array nums of n integers and an integer target, are there elements a, b, c, and d in nums such that a + b + c + d = target? 
    /// Find all unique quadruplets in the array which gives the sum of target.
    /// </summary>
    class _4Sum : ISolution
    {
        public string Method()
        {
            //var nums = new int[] { 1, 0, -1, 0, -2, 2 };
            var nums = new int[] { -3, -2, -1, 0, 0, 1, 2, 3 };
            var target = 0;
            var ans = FourSum(nums, target);
            var result = "";
            foreach (var item in ans)
            {
                foreach (var ele in item)
                {
                    result += "," + ele.ToString();
                }
                result += Environment.NewLine;
            }
            return result;
        }

        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums);
            var result = new List<IList<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                var num1 = nums[i];
                for (int j = i + 1; j < nums.Length; j++)
                {
                    var num2 = nums[j];
                    var k = j + 1;
                    var l = nums.Length - 1;
                    while (k < l)
                    {
                        var num3 = nums[k];
                        var num4 = nums[l];
                        if (num1 + num2 + num3 + num4 == target)
                        {
                            if (!result.Any(x => x.ElementAt(0) == num1 && x.ElementAt(1) == num2 && x.ElementAt(2) == num3))
                                result.Add(new List<int> { num1, num2, num3, num4 });                            
                            k++;
                            l--;
                        }
                        else if (num1 + num2 + num3 + num4 < target)
                            k++;
                        else
                            l--;
                    }                    
                }
            }
            return result;
        }
    }
}
