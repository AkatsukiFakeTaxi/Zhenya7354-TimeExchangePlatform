namespace TimeExchangePlatform.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Category { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
        // FK to User
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
