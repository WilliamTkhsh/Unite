using Unite.Domain.Enums;

namespace Unite.Domain.Entities
{
    public class LeagueEntry
    {
        public QueueType QueueType { get; set; }

        public Tier Tier { get; set; }

        public string Division { get; set; }
    }
}
