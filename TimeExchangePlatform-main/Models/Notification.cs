namespace TimeExchangePlatform.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Message { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; } = false;
        // FK to User
        public string UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
