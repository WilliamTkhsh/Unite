namespace Unite.WebApi.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public LeagueProfile? LeagueProfile { get; set; }
        public Offer? offer { get; set; }
        public List<Subscription>? Subscriptions { get; set; }
    }
}
