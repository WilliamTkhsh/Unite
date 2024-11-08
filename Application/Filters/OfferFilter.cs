using Unite.Domain.Entities;
using Unite.Domain.Enums;

namespace Unite.Application.Filters
{
    public class OfferFilter
    {
        public string? Queue { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string? TargetTier { get; set; }

        public bool? IsTierRestricted { get; set; }

        public Position? TargetPosition { get; set; }

        public OfferStatus? Status { get; set; }

        public List<Subscription>? Subscriptions { get; set; }
    }
}
