
using Microsoft.EntityFrameworkCore;
using TimeExchangePlatform.Data;
using TimeExchangePlatform.Models;

namespace TimeExchangePlatform.Services
{
    public class AgreementService(TEPDbContext dbContext) : IAgreementService
    {
        private readonly TEPDbContext _dbContext = dbContext;

        public async Task ChangeStatus(ExchangeStatus status, int agreementId, string currentUserId)
        {
            var agreement = await _dbContext.agreements.Include(a => a.Provider).Include(a => a.Receiver).FirstOrDefaultAsync(a => a.Id == agreementId);
            if (agreement == null) throw new KeyNotFoundException("Agreement not found");
            if(agreement.ProviderUserId != currentUserId)
                throw new UnauthorizedAccessException("Only the provider can change the agreement status");
            if (agreement.Status != ExchangeStatus.Pending)
                throw new InvalidOperationException("Agreement already processed");

            agreement.Status = status;

            if(agreement.Receiver.TimePoints - agreement.Hours < 0)
                throw new InvalidOperationException("Receiver does not have enough time points");
            agreement.Provider.TimePoints += agreement.Hours;
            agreement.Receiver.TimePoints -= agreement.Hours;

            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateAgreementAsync(int offerId,int hours, string receiverUserId)
        {
            var offer = await _dbContext.offers.FirstOrDefaultAsync(o => o.Id == offerId);

            // Different exception type for not found offer
            if ( offer == null) throw new KeyNotFoundException("Offer not found");

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
            // Easier way to validate if agreement exists, but inconvinient for larger methods(with for instance 3 - 5 states)
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
