using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Stripe.BLL
{
    public static class DependenciesBootstrapper
    {
        public static IServiceCollection AddStripeBll(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
