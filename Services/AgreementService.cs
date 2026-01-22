
using Microsoft.EntityFrameworkCore;
using TimeExchangePlatform.Data;
using TimeExchangePlatform.Models;

namespace TimeExchangePlatform.Services
{
    public class AgreementService(TEPDbContext dbContext) : IAgreementService
    {
        private readonly TEPDbContext _dbContext = dbContext;

        public async Task ChangeStatus(ExchangeStatus status, int agreementId)
        {
            var agreement = await _dbContext.agreements.FirstOrDefaultAsync(a => a.Id == agreementId);
            if (agreement == null) return;
            agreement.Status = status;
            await _dbContext.SaveChangesAsync();
        }

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

        public async Task<int> DeleteAgreementAsync(int agreementId)
        {
            var agreementToDelete = await _dbContext.agreements.FirstOrDefaultAsync(a => a.Id == agreementId);
            if (agreementToDelete != null)
            {
                _dbContext.agreements.Remove(agreementToDelete);
                return await _dbContext.SaveChangesAsync();
            }
            return -1;
        }

        async Task<List<Agreement>> IAgreementService.GetUserAgreementsAsync(string userId)
        {
            var agreements = await _dbContext.agreements.Include(a => a.Offer).Include(a => a.Provider).Include(a => a.Receiver)
                                            .Where(a => a.ProviderUserId == userId || a.ReceiverUserId == userId).ToListAsync();
            return agreements;
        }

    }
}
