using MediatR;
using System.Text.Json.Serialization;

namespace Stripe.BLL.Subscriptions.Commands.Cancel
{
    public class CancelSubscriptionCommand : IRequest<string>
    {
        [JsonPropertyName("subscription_id")]
        public string SubscriptionId { get; set; }
    }
}
