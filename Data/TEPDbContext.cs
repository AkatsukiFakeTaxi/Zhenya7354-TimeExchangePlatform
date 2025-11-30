using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimeExchangePlatform.Models;

namespace TimeExchangePlatform.Data
{
    public class TEPDbContext(DbContextOptions<TEPDbContext> options) : IdentityDbContext<User>(options)
    {
        public DbSet<User> users { get; set; }
        public DbSet<Offer> offers { get; set; }
        public DbSet<Exchange> exchanges { get; set; }
        public DbSet<Review> reviews { get; set; }
        public DbSet<Notification> notifications { get; set; }
        public DbSet<Skill> skills { get; set; }
        public DbSet<Request> requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Review>()
                .HasOne(r=>r.ReviewerUser)
                .WithMany()
                .HasForeignKey(r => r.ReviewerUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.ReviewedUser)
                .WithMany()
                .HasForeignKey(r => r.ReviewedUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
        }

    
}
