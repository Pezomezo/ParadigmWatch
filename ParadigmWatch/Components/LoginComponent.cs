using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ParadigmWatch.Models;
using ParadigmWatch.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParadigmWatch.Components
{
    public class LoginComponent : ViewComponent
    {
        //private readonly UserManager<AppUser> _userManager;
        //private readonly SignInManager<AppUser> _signInManager;
        //public LoginComponent(UserManager<AppUser> userMgr,
        //SignInManager<AppUser> signinMgr)
        //{
        //    _userManager = userMgr;
        //    _signInManager = signinMgr;
        //}

        //[AllowAnonymous]
        //public IViewComponentResult Invoke(string returnUrl)
        //{
        //    ViewBag.returnUrl = returnUrl;
        //    return View();
        //}

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<IViewComponentResult> IndexAsync(LoginModel model, string returnUrl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        AppUser user = await _userManager.FindByEmailAsync(model.Email);
        //        if (user != null)
        //        {
        //            await _signInManager.SignOutAsync();
        //            Microsoft.AspNetCore.Identity.SignInResult result =
        //                await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
        //            if (result.Succeeded)
        //            {
        //                return Redirect(returnUrl ?? "/");
        //            }
        //        }
        //        ModelState.AddModelError(nameof(LoginModel.Email), "Invalid user or password");
        //    }
        //    return View(model);
        //}


        //[Authorize]
        //public async Task<IViewComponentResult> Logout()
        //{
        //    await _signInManager.SignOutAsync();
        //    return RedirectToAction("Index", "Home");
        //}

        //[AllowAnonymous]
        //public IViewComponentResult AccessDenied()
        //{
        //    return View();
        //}
    }
}
