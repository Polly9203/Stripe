using Microsoft.EntityFrameworkCore;
using Stripe.DAL.Models;

namespace Stripe.DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<SubscriptionModel> SubscriptionsCreatedHistory { get; set; }
    }
}
