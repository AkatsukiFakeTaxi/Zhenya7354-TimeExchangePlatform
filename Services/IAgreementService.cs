using TimeExchangePlatform.Models;

namespace TimeExchangePlatform.Services
{
    public interface IAgreementService
    {
        Task CreateAgreementAsync(int offerId,int hours, string receiverUserId);
        Task<List<Agreement>> GetUserAgreementsAsync(string userId);
        Task ChangeStatus(ExchangeStatus status, int agreementId);
    }
}
