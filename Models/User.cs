using Microsoft.AspNetCore.Identity;

namespace TimeExchangePlatform.Models
{
    public class User : IdentityUser
    {
        public string? FullName { get; set; }
        public string? Bio { get; set; }
        public string? City { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? PhoneNumber { get; set; }
        public int TimePoints { get; set; } = 0;
        public bool IsPremiumMember { get; set; } = false;
        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;

    }
}
