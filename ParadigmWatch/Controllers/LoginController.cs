using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ParadigmWatch.Models;
using ParadigmWatch.Models.ViewModels;

namespace ParadigmWatch.Controllers
{
    public class LoginController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private IUserValidator<AppUser> userValidator;
        private IPasswordValidator<AppUser> passwordValidator;
        private IPasswordHasher<AppUser> passwordHasher;
        public LoginController(UserManager<AppUser> userMgr,
        SignInManager<AppUser> signinMgr, IUserValidator<AppUser> userValid,
            IPasswordValidator<AppUser> passValid,
            IPasswordHasher<AppUser> passwordHash)
        {
            _userManager = userMgr;
            _signInManager = signinMgr;
            userValidator = userValid;
            passwordValidator = passValid;
            passwordHasher = passwordHash;
        }

        [AllowAnonymous]
        public IActionResult Index(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AdministrationViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByEmailAsync(model.LoginModel.Email);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result =
                        await _signInManager.PasswordSignInAsync(user, model.LoginModel.Password, false, false);
                    if (result.Succeeded)
                    {
                        return Redirect(returnUrl ?? "/");
                    }
                }
                ModelState.AddModelError(nameof(AdministrationViewModel.LoginModel.Email), "Invalid user or password");
            }
            return View(model);
        }

        public ViewResult SignUp() => View();
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp(AdministrationViewModel model)
        {

            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = model.SignUpModel.FirstName,
                    FirstName = model.SignUpModel.FirstName,
                    LastName = model.SignUpModel.LastName,
                    Email = model.SignUpModel.Email,
                    Address = model.SignUpModel.Address,
                    ZipCode = model.SignUpModel.ZipCode,
                    City = model.SignUpModel.City
                };
                IdentityResult result = await _userManager.CreateAsync(user, model.SignUpModel.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }     

    }
}