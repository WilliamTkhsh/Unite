using Unite.WebApi.Domain.Enums;

namespace Unite.WebApi.Application.ViewModels.Offers
{
    public class OfferInput
    {
        public string Queue { get; set; }

        public string TargetTier { get; set; }

        public bool IsTierRestricted { get; set; }

        public Position? TargetPosition1 { get; set; }

        public Position? TargetPosition2 { get; set; }

        public Position? TargetPosition3 { get; set; }

        public Position? TargetPosition4 { get; set; }

        public string? Notes { get; set; }
    }
}
