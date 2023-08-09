using Microsoft.Extensions.Options;
using Stripe.DAL.Repositories;

namespace Stripe.BLL.WebHooks
{
    public class WebHookService : IWebHookService
    {
        private readonly StripeSettings stripeSettings;
        private readonly IWebHooksRepository _webHooksRepository;
        public WebHookService(IOptions<StripeSettings> stripeSettings, IWebHooksRepository webHooksRepository) 
        {
            this.stripeSettings = stripeSettings.Value;
            _webHooksRepository = webHooksRepository ?? throw new ArgumentNullException(nameof(webHooksRepository));
        }

        public async Task SubscriptionCreated(Event stripeEvent)
        {
            var subscription = stripeEvent.Data.Object as Subscription;

            StripeConfiguration.ApiKey = stripeSettings.SecretKey;
            var service = new SubscriptionService();
            var fetchedSubscription = await service.GetAsync(subscription.Id);

            _webHooksRepository.SubscriptionCreated(fetchedSubscription.Id, fetchedSubscription.Created, fetchedSubscription.Status, fetchedSubscription.CustomerId);
        }
    }
}
