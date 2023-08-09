using Stripe.DAL.Models;

namespace Stripe.DAL.Repositories
{
    public class WebHooksRepository : IWebHooksRepository
    {
        private readonly ApplicationContext _applicationContext;
        public WebHooksRepository(ApplicationContext applicationContext) 
        {
            _applicationContext = applicationContext;
        }
        public void SubscriptionCreated(string id, DateTime created, string status, string customerId)
        {
            var subscription = new SubscriptionModel() { Id = id, Created = created, Status = status, CustomerId = customerId };
            
            _applicationContext.SubscriptionsCreatedHistory.Add(subscription);
            _applicationContext.SaveChanges();
        }
    }
}
