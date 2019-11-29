using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeTest
{
    public static class SolutionFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        public static IServiceCollection AddScoped(this IServiceCollection services, string assemblyName, Func<string, ISolution> factory)
        {
            services.AddScoped<ISolution>(x => {
                return factory.Invoke(assemblyName);
            });

            return services;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        public static T GetRequiredService<T>(this IServiceProvider provider, string assemblyName, Func<string, T> factory)
        {
            return factory.Invoke(assemblyName);
        }
    }
}
