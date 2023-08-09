using Microsoft.Extensions.DependencyInjection;
using Stripe.BLL.WebHooks;
using System.Reflection;

namespace Stripe.BLL
{
    public static class DependenciesBootstrapper
    {
        public static IServiceCollection AddStripeBll(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddTransient<IWebHookService, WebHookService>();

            return services;
        }
    }
}
