using MediatR;

namespace Stripe.BLL.Subscriptions.Commands.Create
{
    public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, string>
    {
        public async Task<string> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var service = new SubscriptionService();
            var options = new SubscriptionCreateOptions
            {
                Customer = request.CustomerId,
                Items = new List<SubscriptionItemOptions>
                {
                    new SubscriptionItemOptions
                    {
                        Price = request.PriceId
                    }
                }
            };

            var subscription = await service.CreateAsync(options);

            return subscription.Id;
        }
    }
}
