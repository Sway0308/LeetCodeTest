using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCodeTest.Tests
{
    /// <summary>
    /// Given an array with n objects colored red, white or blue, sort them in-place so that objects of the same color are adjacent, 
    /// with the colors in the order red, white and blue.
    /// 
    /// Here, we will use the integers 0, 1, and 2 to represent the color red, white, and blue respectively.
    /// 
    /// Note: You are not suppose to use the library's sort function for this problem.
    /// </summary>
    class Sort_Colors : ISolution, IMedium, IComplete
    {
        public string Method()
        {
            var nums = new int[] { 2, 0, 2, 1, 1, 0 };
            SortColors(nums);
            var ans = string.Join(",", nums.Select(x => x.ToString()));
            return ans;
        }

        public void SortColors(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return;

            var queue = new Queue<int>();
            for (int i = 0; i <= 2; i++)
            {
                foreach (var item in nums)
                {
                    if (item == i)
                        queue.Enqueue(item);
                }
            }
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = queue.Dequeue();
            }
        }
    }
}
