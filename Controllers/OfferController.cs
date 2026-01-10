using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TimeExchangePlatform.Data;
using TimeExchangePlatform.Models;
using TimeExchangePlatform.Services;

namespace TimeExchangePlatform.Controllers
{
    //[Authorize] - Commented for testing purposes
    public class OfferController : Controller
    {
        private readonly IOfferService _offerService;

        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }
        public async Task<IActionResult> Index()
        {
            var offers = await _offerService.GetOffersAsync();
            return View(offers);
        }
        public async Task<IActionResult> OfferDetails(int offerId)
        {
            var offer = await _offerService.GetOfferByIdAsync(offerId);

            if (offer == null) return NotFound();

            return View(offer);
        }
    }
}
