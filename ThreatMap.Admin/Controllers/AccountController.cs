using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThreatMap.Admin.ViewModels.Account;
using ThreatMap.Domain.Identity.Entities;
using ThreatMap.Domain.Identity.Static;

namespace ThreatMap.Admin.Controllers
{
    [Route("account")]
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        private readonly SignInManager<User> _signInManager;

        public AccountController(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        // -------------------- Login methods -------------------- //

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginVM vm, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }


            var result = await _signInManager.PasswordSignInAsync(vm.Email, vm.Password, vm.RememberMe, false);
            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    LocalRedirect(returnUrl);
                }
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}