using System.Linq;
using System.Reflection;

using Microsoft.Extensions.DependencyInjection;
using TrollsVsElves.Core.Lifetime;

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
    }
}