using TimeExchangePlatform.Models;

namespace TimeExchangePlatform.Services
{
    public interface IOfferService
    {
        Task<List<Offer>> GetOffersAsync();
        Task<Offer> GetOfferByIdAsync(int offerId);
        Task<int> AddOffer(Offer offer);
        Task<int> UpdateOffer(Offer offer);
        Task<int> RemoveOffer(int offerId);
    }
}
