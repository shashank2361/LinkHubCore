using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LHBOL;
using LHUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LHUI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {

        UserManager<LHUser> userManager;
        SignInManager<LHUser> signInManager;

        public AccountController(UserManager<LHUser> _userManager, SignInManager<LHUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                LHUser user = new LHUser()
                {
                    UserName = model.UserName,
                    Email = model.Email
                };

                var resultCreate = await userManager.CreateAsync(user, model.Password);
                var resultRoleAssign = await userManager.AddToRoleAsync(user, "User");
                var resultSign = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, true);

                if (resultSign.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var Result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, true);

                if (Result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

    }
}