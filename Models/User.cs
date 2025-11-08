namespace TimeExchangePlatform.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string? Bio { get; set; }
        public string? City { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? PhoneNumber { get; set; }
        public int TimePoints { get; set; } = 0;
        public bool IsPremiumMember { get; set; } = false;
        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;

    }
}
