using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExploreCalifornia57.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExploreCalifornia57.Controllers
{
    public class AccountController : Controller
    {
        /*
        public IActionResult Index()
        {
            return View();
        }*/

        private readonly UserManager<IdentityUser> _userManager57;
        private readonly SignInManager<IdentityUser> _signInManager57;

        public AccountController(UserManager<IdentityUser> userManager57,
            SignInManager<IdentityUser> signInManager57)
        {
            _userManager57 = userManager57;
            _signInManager57 = signInManager57;
        }


        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _signInManager57.PasswordSignInAsync(
                login.EmailAddress57, login.Password57,
                login.RememberMe57, false
            );

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Login error!");
                return View();
            }

            if (string.IsNullOrWhiteSpace(returnUrl))
                return RedirectToAction("Index", "Home");

            return Redirect(returnUrl);
        }

        [HttpPost]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager57.SignOutAsync();

            if (string.IsNullOrWhiteSpace(returnUrl))
                return RedirectToAction("Index", "Home");

            return Redirect(returnUrl);
        }

        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registration57)
        {
            if (!ModelState.IsValid)
                return View(registration57);

            var newUser = new IdentityUser
            {
                Email = registration57.EmailAddress57,
                UserName = registration57.EmailAddress57,
            };

            var result = await _userManager57.CreateAsync(newUser, registration57.Password57);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors.Select(x => x.Description))
                {
                    ModelState.AddModelError("", error);
                }

                return View();
            }

            return RedirectToAction("Login");
        }
    }
}