namespace Stripe.BLL.WebHooks
{
    public interface IWebHookService
    {
        Task SubscriptionCreated(Event stripeEvent);
    }
}
