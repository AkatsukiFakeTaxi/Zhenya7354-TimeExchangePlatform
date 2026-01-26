using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TimeExchangePlatform.Models;
using TimeExchangePlatform.Services;
using TimeExchangePlatform.ViewModels;

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
        public IActionResult CreateAgreement(int offerId)
        {
            var offer = new CreateAgreementViewModel
            {
                OfferId = offerId
            };
            return View(offer);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAgreement(CreateAgreementViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var receiverUserId = _userManager.GetUserId(User) ?? "0";
            var offer = await _offerService.GetOfferByIdAsync(viewModel.OfferId);
            try
            {
                await _agreementService.CreateAgreementAsync(viewModel.OfferId, viewModel.Hours, receiverUserId);
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            // Make separate method to deactivate offer
            offer.IsActive = false;
            await _offerService.UpdateOffer(offer);

            return RedirectToAction("Index", "Offer");
        }
        [HttpGet]
        public async Task<IActionResult> GetUserAgreements()
        {
            var userId = _userManager.GetUserId(User) ?? "0";
            var agreements = await _agreementService.GetUserAgreementsAsync(userId);
            return View(agreements);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAgreement(int agreementId)
        {
            var result = await _agreementService.DeleteAgreementAsync(agreementId);
            if(result == -1)
            {
                return NotFound($"Agreement with {agreementId} does not exist");
            }
            return RedirectToAction("GetUserAgreements");
        }

        [HttpPost]
        public async Task<IActionResult> CancelAgreement(int agreementId)
        {
            try
            {
                await _agreementService.ChangeStatus(ExchangeStatus.Cancelled, agreementId);
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
                return RedirectToAction("GetUserAgreements");
            
        }
    }
}
