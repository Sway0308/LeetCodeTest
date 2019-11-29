using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCodeTest.Tests
{
    /// <summary>
    /// There are n cities connected by m flights. Each fight starts from city u and arrives at v with a price w.
    /// Now given all the cities and flights, together with starting city src and the destination dst, 
    /// your task is to find the cheapest price from src to dst with up to k stops.If there is no such route, output -1.
    /// </summary>
    class Cheapest_Flights_Within_K_Stops : ISolution, IMedium
    {
        public string Method()
        {
            var n = 3;
            var flights = new int[][] { new int[] { 0, 1, 100 }, new int[] { 1, 2, 100 }, new int[] { 0 , 2, 500 } };
            var src = 0;
            var dst = 2;
            var k = 1;
            var ans = FindCheapestPrice(n, flights, src, dst, k);
            return ans.ToString();
        }

        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K)
        {
            var allStops = K + 2;
            var sequence = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                sequence.Add(n);
            }

            var allCombinations = new List<List<int>>();
            foreach (var item in sequence.Where(x => x != src && x != dst))
            {
                var combine = new List<int>();
                var i = 1;
                while (combine.Count < K)
                {
                    if (i == src || i == dst || i == item)
                        continue;
                    combine.Add(i);
                    i++;
                }
                allCombinations.Add(combine);
            }

            return -1;
        }
    }
}
