namespace Unite.WebApi.Domain.Entities
{
    public class LeagueProfile
    {
        public string Nickname { get; set; }

        public string Tag { get; set; }

        public List<LeagueEntry> LeagueEntries { get; set; }
    }
}
