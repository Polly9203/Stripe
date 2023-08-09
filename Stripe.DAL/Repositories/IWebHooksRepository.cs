namespace Stripe.DAL.Repositories
{
    public interface IWebHooksRepository
    {
        void SubscriptionCreated(string id, DateTime created, string status, string customerId);
    }
}
