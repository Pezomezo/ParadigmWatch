using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ParadigmWatch.Models;
using ParadigmWatch.Models.ViewModels;

namespace ParadigmWatch.Controllers.Store
{
    public class SignUpController : Controller
    {
        private UserManager<AppUser> userManager;

        private IUserValidator<AppUser> userValidator;
        private IPasswordValidator<AppUser> passwordValidator;
        private IPasswordHasher<AppUser> passwordHasher;
        public SignUpController(UserManager<AppUser> usrMgr,
            IUserValidator<AppUser> userValid,
            IPasswordValidator<AppUser> passValid,
            IPasswordHasher<AppUser> passwordHash)
        {
            userManager = usrMgr;
            userValidator = userValid;
            passwordValidator = passValid;
            passwordHasher = passwordHash;
        }

        [HttpGet]
        public ViewResult Incex() => View();

        [HttpPost]
        public async Task<IActionResult> Index(CreateModel model)
        {
            if (ModelState.IsValid && model != null)
            {
                AppUser user = new AppUser
                {
                    UserName = "Adamka",
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.SignUpEmail,
                    Address = model.Address,
                    ZipCode = model.ZipCode,
                    City = model.City
                };
                IdentityResult result = await userManager.CreateAsync(user, model.Password);

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
    }
}