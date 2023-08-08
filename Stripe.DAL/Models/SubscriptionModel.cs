namespace Stripe.DAL.Models
{
    public class SubscriptionModel
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public string Status { get; set; }
        public string CustomerId { get; set; }
    }
}
