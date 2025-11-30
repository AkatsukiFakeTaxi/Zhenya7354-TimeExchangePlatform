using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TimeExchangePlatform.Models;
using TimeExchangePlatform.ViewModels;

namespace TimeExchangePlatform.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public AccountController(SignInManager<User> _signInManager, UserManager<User> _userManager)
        {
            signInManager = _signInManager;
            userManager = _userManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                User user = new User
                {
                    Email = model.Email,
                    UserName = model.Email,
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if(result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }
            }
            return View(model);
        }
        public IActionResult VerifyEmail()
        {
            return View();
        }
        public IActionResult ChangePassword()
        {
            return View();
        }

    }
}
