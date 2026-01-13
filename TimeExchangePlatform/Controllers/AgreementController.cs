using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TimeExchangePlatform.Models;
using TimeExchangePlatform.Services;

namespace TimeExchangePlatform.Controllers
{
    public class AgreementController : Controller
    {
        private readonly IAgreementService _agreementService;
        private readonly IOfferService _offerService;
        private readonly UserManager<User> _userManager;
        public AgreementController(IAgreementService agreementService, UserManager<User> userManager,IOfferService offerService)
        {
            _agreementService = agreementService;
            _userManager = userManager;
            _offerService = offerService;
        }
        [HttpGet]
        public IActionResult CreateAgreement()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAgreement(int offerId, int hours)
        {
            var receiverUserId = _userManager.GetUserId(User) ?? "0";
            var offer = await _offerService.GetOfferByIdAsync(offerId);

            await _agreementService.CreateAgreementAsync(offerId,hours,receiverUserId);

            offer.IsActive = false;
            await _offerService.UpdateOffer(offer);

            return RedirectToAction("Index", "Offer");
        }
    }
}
