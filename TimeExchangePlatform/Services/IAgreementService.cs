namespace TimeExchangePlatform.Services
{
    public interface IAgreementService
    {
        Task CreateAgreementAsync(int offerId,int hours, string receiverUserId);
    }
}
