using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TimeExchangePlatform.Data;
using TimeExchangePlatform.Models;
using TimeExchangePlatform.Services;
using TimeExchangePlatform.ViewModels;

namespace TimeExchangePlatform.Controllers
{
    //[Authorize] - Commented for testing purposes
    public class OfferController : Controller
    {
        private readonly IOfferService _offerService;
        private readonly UserManager<User> _userManager;

        public OfferController(IOfferService offerService, UserManager<User> userManager)
        {
            _offerService = offerService;
            _userManager = userManager;
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
        [Authorize]
        [HttpGet]
        public IActionResult CreateOffer()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateOffer(CreateOfferViewModel offerViewModel)
        {
            if (!ModelState.IsValid) return View(offerViewModel);

            var offer = new Offer
            {
                Title = offerViewModel.Title,
                Category = offerViewModel.Category,
                Description = offerViewModel.Description,
                CreatedAt = DateTime.UtcNow,
                UserId = _userManager.GetUserId(User) ?? "0",
                IsActive = true
            };

            await _offerService.AddOffer(offer);
            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteOffer(int offerId)
        {
            int result = await _offerService.RemoveOffer(offerId);
            if (result == -1) return NotFound();
            return RedirectToAction("Index", "Offer");
        }
    }
}
