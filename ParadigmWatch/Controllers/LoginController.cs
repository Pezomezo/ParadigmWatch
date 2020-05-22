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
        // #################### LOGIN #############################

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public LoginController(UserManager<AppUser> userMgr,
        SignInManager<AppUser> signinMgr)
        {
            _userManager = userMgr;
            _signInManager = signinMgr;
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
        public async Task<IActionResult> IndexAsync(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result =
                        await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        return Redirect(returnUrl ?? "/");
                    }
                }
                ModelState.AddModelError(nameof(LoginModel.Email), "Invalid user or password");
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


        // #################### Sign UP #######################

        //private UserManager<AppUser> userManager;

        //private IUserValidator<AppUser> userValidator;
        //private IPasswordValidator<AppUser> passwordValidator;
        //private IPasswordHasher<AppUser> passwordHasher;
        //public LoginController(UserManager<AppUser> usrMgr,
        //    IUserValidator<AppUser> userValid,
        //    IPasswordValidator<AppUser> passValid,
        //    IPasswordHasher<AppUser> passwordHash)
        //{
        //    userManager = usrMgr;
        //    userValidator = userValid;
        //    passwordValidator = passValid;
        //    passwordHasher = passwordHash;
        //}

        //public ViewResult Index() => View();
        //[HttpPost]
        //public async Task<IActionResult> Index(CreateModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        AppUser user = new AppUser
        //        {
        //            UserName = "Adamka",
        //            FirstName = model.FirstName,
        //            LastName = model.LastName,
        //            Email = model.Email,
        //            Address = model.Address,
        //            ZipCode = model.ZipCode,
        //            City = model.City
        //        };
        //        IdentityResult result = await userManager.CreateAsync(user, model.Password);

        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            foreach (IdentityError error in result.Errors)
        //            {
        //                ModelState.AddModelError("", error.Description);
        //            }
        //        }
        //    }
        //    return View(model);
        //}


    }
}