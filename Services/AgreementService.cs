
using Microsoft.EntityFrameworkCore;
using TimeExchangePlatform.Data;
using TimeExchangePlatform.Models;

namespace TimeExchangePlatform.Services
{
    public class AgreementService(TEPDbContext dbContext) : IAgreementService
    {
        private readonly TEPDbContext _dbContext = dbContext;
        public async Task CreateAgreementAsync(int offerId,int hours, string receiverUserId)
        {
            var offer = await _dbContext.offers.FirstOrDefaultAsync(o => o.Id == offerId) ?? new Offer();
            

            var agreement = new Agreement
            {
                OfferId = offerId,
                Hours = hours,
                ProviderUserId = offer.UserId,
                ReceiverUserId = receiverUserId,
            };

            _dbContext.agreements.Add(agreement);
            await _dbContext.SaveChangesAsync();
        }
    }
}
