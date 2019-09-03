using System;

namespace LeetCodeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = GetSolution("LeetCodeTest.Longest_Common_Prefix");
            var strTime = DateTime.Now;
            Console.WriteLine(strTime);
            var ans = SoluteMethod(sol);
            var endTime = DateTime.Now;
            Console.WriteLine(endTime);
            Console.WriteLine("Total time：" + (endTime - strTime).TotalMilliseconds);
            Console.WriteLine("Ans：" + ans);
            Console.ReadKey();
        }

        private static ISolution GetSolution(string assemblyName)
        {
            var type = Type.GetType(assemblyName);
            var sol = Activator.CreateInstance(type) as ISolution;
            return sol;
        }

        private static string SoluteMethod(ISolution solution)
        {
            return solution.Method();
        }
    }
}
