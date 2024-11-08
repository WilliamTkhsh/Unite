using Unite.Domain.Enums;

namespace Unite.Domain.Entities
{
    public class Subscription
    {
        public Position Position { get; set; }

        public string Notes { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
