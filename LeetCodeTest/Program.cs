using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var type = typeof(ISolution);
            var completeType = typeof(IComplete);
            var matchTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => !completeType.IsAssignableFrom(x) && type.IsAssignableFrom(x) && x != type);
            var dic = new Dictionary<int, string>();
            var services = new ServiceCollection();
            for (int i = 0; i < matchTypes.Count(); i++)
            {
                var assemblyName = matchTypes.ElementAt(i).FullName;
                dic.Add(i + 1, assemblyName);
                services.AddScoped(assemblyName, GetSolution);
            }



            var a = services.BuildServiceProvider().GetRequiredService("LeetCodeTest.Tests.Sort_Colors", GetSolution);
            var b = a.Method();

            StartTest(dic);
        }

        private static IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ISolution>(x => {
                return GetSolution("");
            });
            return services;
        }

        private static void StartTest(Dictionary<int, string> dic)
        {
            Console.Clear();

            foreach (var key in dic.Keys)
            {
                Console.WriteLine($"{key}. {dic[key]}");
            }

            var ans = Console.ReadLine();
            if (ans.Equals("Exit", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("bye bye");
                Console.ReadKey();
                return;
            }
            else if (!int.TryParse(ans, out var number))
            {
                Console.WriteLine("Wrong input");
                Console.ReadKey();
            }
            else if (!dic.ContainsKey(number))
            {
                Console.WriteLine("Wrong number");
                Console.ReadKey();
            }
            else
            {
                DoTest(dic[number]);
            }

            StartTest(dic);
        }

        private static void DoTest(string assemblyName)
        {
            var sol = GetSolution(assemblyName);
            var strTime = DateTime.Now;
            Console.WriteLine(strTime);
            var ans = SoluteMethod(sol);
            var endTime = DateTime.Now;
            Console.WriteLine(endTime);
            Console.WriteLine("Total time：" + (endTime - strTime).TotalMilliseconds);
            Console.WriteLine("Ans：" + ans);
            Console.ReadKey();

            Console.WriteLine("Another Test?....(Y)");
            var continueTest = Console.ReadLine();
            if (continueTest.ToUpper() != "Y")
            {
                Console.WriteLine("Continue Test：" + assemblyName);
                DoTest(assemblyName);
            }
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
