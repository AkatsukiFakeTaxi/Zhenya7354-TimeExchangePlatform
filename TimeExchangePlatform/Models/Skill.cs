namespace TimeExchangePlatform.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        // FK to User
        public string UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
