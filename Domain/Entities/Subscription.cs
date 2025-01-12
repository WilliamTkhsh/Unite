using Unite.WebApi.Domain.Enums;

namespace Unite.WebApi.Domain.Entities
{
    public class Subscription
    {
        public int SubscriptionId { get; set; }

        public Guid OfferId { get; set; }

        public Guid UserId { get; set; }

        public Position Position { get; set; }

        public string Notes { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
