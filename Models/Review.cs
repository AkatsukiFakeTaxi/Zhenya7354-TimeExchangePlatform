namespace TimeExchangePlatform.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; } // e.g., 1 to 5
        public string Comment { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        // FK to User who is reviewed
        public int ReviewedUserId { get; set; }
        public User ReviewedUser { get; set; } = null!;
        // FK to User who wrote the review
        public int ReviewerUserId { get; set; }
        public User ReviewerUser { get; set; } = null!;
    }
}
