using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TimeExchangePlatform.Data;
using TimeExchangePlatform.Models;

namespace TimeExchangePlatform.Services
{
    public class OfferService : IOfferService
    {
        private readonly TEPDbContext _dbContext;

        public OfferService(TEPDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }
        public async Task<int> AddOffer(Offer offer)
        {
            _dbContext.offers.Add(offer);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Offer> GetOfferByIdAsync(int offerId)
        {
            return await _dbContext.offers.Include(o=>o.User).FirstOrDefaultAsync(o => o.Id == offerId && o.IsActive)
                ?? new Offer();
        }

        public async Task<List<Offer>> GetOffersAsync()
        {
            return await _dbContext.offers.Where(o => o.IsActive).ToListAsync();
        }

        public async Task<int> RemoveOffer(int offerId)
        {
            var offerToDelete = await _dbContext.offers.FindAsync(offerId);
            if (offerToDelete != null)
            {
                _dbContext.offers.Remove(offerToDelete);
                return await _dbContext.SaveChangesAsync();
            }
            return -1;
        }

        public async Task<int> UpdateOffer(Offer offer)
        {
            _dbContext.offers.Update(offer);
            return await _dbContext.SaveChangesAsync();
        }

        private void SeedData()
        {
           _dbContext.offers.AddRange(
                new Offer
                {
                    
                    Title = "Help with math",
                    Description = "Can help with basic algebra",
                    Category = "Education",
                    UserId = "7ca9b901-2267-4385-80fa-9460cb4a6eb0"
                },
                new Offer
                {
                    
                    Title = "Pc repair",
                    Description = "Can help with pc problems",
                    Category = "IT",
                    UserId = "7ca9b901-2267-4385-80fa-9460cb4a6eb0"
                }
                );
             _dbContext.SaveChanges();
            Debug.WriteLine(_dbContext.offers.Count());
        }
    }
}
