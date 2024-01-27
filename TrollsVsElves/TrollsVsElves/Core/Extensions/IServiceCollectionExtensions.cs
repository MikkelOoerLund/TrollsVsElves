using System.Linq;
using System.Reflection;

using Microsoft.Extensions.DependencyInjection;
using TrollsVsElves.Core.Abstractions;

namespace TrollsVsElves.Core.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddTransientServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var transients = assembly.GetTypes().Where(x => x.IsAssignableTo(typeof(ITransient)) && !x.IsInterface && !x.IsAbstract);

            foreach (var transient in transients)
            {
                services.AddTransient(transient);
            }

            return services;
        }

        public static IServiceCollection AddSingletonServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var singletons = assembly.GetTypes().Where(x => x.IsAssignableTo(typeof(ISingleton)) && !x.IsInterface && !x.IsAbstract);

            foreach (var singleton in singletons)
            {
                services.AddSingleton(singleton);
            }

            return services;
        }
    }
}