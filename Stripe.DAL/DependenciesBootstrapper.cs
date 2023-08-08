using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Stripe.DAL.Repositories;

namespace Stripe.DAL
{
    public static class DependenciesBootstrapper
    {
        public static IServiceCollection AddStripeDAL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IWebHooksRepository, WebHooksRepository>();

            return services;
        }
    }
}
