using MediatR;

namespace Stripe.BLL.Subscriptions.Commands.Cancel
{
    public class CancelSubscriptionCommandHandler : IRequestHandler<CancelSubscriptionCommand, string>
    {
        public async Task<string> Handle(CancelSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var service = new SubscriptionService();
            var canceledSubscription = await service.CancelAsync(request.SubscriptionId, null, null);

            return canceledSubscription.Status;
        }
    }
}
