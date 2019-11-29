using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeTest
{
    /// <summary>
    /// Given n non-negative integers a1, a2, ..., an , 
    /// where each represents a point at coordinate (i, ai). n vertical lines are drawn such that the two endpoints of line i is at (i, ai) and (i, 0). Find two lines, 
    /// which together with x-axis forms a container, such that the container contains the most water.-
    /// </summary>
    class Container_With_Most_Water : ISolution, IMedium, IComplete
    {
        public string Method()
        {
            var height = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            var area = MaxArea(height);
            return area.ToString();
        }

        private int MaxArea(int[] height)
        {
            var max = 0;
            for (int i = 0; i < height.Length; i++)
            {
                for (int j = i + 1; j < height.Length; j++)
                {
                    var min = Math.Min(height[i], height[j]);
                    var area = min * (j - i);
                    max = Math.Max(max, area);
                }
            }
            return max;
        }
    }
}
