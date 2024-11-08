using Unite.Domain.Enums;

namespace Unite.Domain.Entities
{
    public class Offer
    {
        public Guid Id { get; set; }

        public string Queue { get; set; }

        public DateTime CreatedAt { get; set; }

        public string TargetTier { get; set; }

        public bool IsTierRestricted { get; set; }

        public Position TargetPosition1 { get; set; }

        public Position TargetPosition2 { get; set; }

        public Position TargetPosition3 { get; set; }

        public Position TargetPosition4 { get; set; }

        public string Notes { get; set; }

        public OfferStatus Status { get; set; }

        public List<Subscription> Subscriptions { get; set; }
    }
}
