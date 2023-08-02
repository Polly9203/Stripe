using MediatR;
using System.Text.Json.Serialization;

namespace Stripe.BLL.Subscriptions.Commands.Create
{
    public class CreateSubscriptionCommand : IRequest<string>
    {
        [JsonPropertyName("customer_id")]
        public string CustomerId { get; set; }

        [JsonPropertyName("price_id")]
        public string PriceId { get; set; }
    }
}
