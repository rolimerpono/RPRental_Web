﻿using DataService.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model;
using RPRENTAL.ViewModels;
using StaticUtility;
using Stripe.Treasury;

namespace RPRENTAL.Controllers
{
    public class AccountController : Controller
    {
        private readonly IWorker _IWorker;
        private readonly UserManager<ApplicationUser> _UserManager;
        private readonly SignInManager<ApplicationUser> _SignInManager;
        private readonly RoleManager<IdentityRole> _RoleManager;

        public AccountController(IWorker IWorker, UserManager<ApplicationUser> ApplicationUser, SignInManager<ApplicationUser> SignInManager, RoleManager<IdentityRole> RoleManager)
        {
            _IWorker = IWorker;
            _UserManager = ApplicationUser;
            _SignInManager = SignInManager;
            _RoleManager = RoleManager;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {         
            return View();

        }     

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            var objSignIn = await _SignInManager.PasswordSignInAsync(loginVM.EMAIL, loginVM.PASSWORD, loginVM.IS_REMEMBER, lockoutOnFailure: false);

            if (objSignIn.Succeeded)
            {
                var objUser = await _UserManager.FindByEmailAsync(loginVM.EMAIL);

                if (await _UserManager.IsInRoleAsync(objUser, SD.UserRole.ADMIN.ToString()))
                {                  
                    return Json(new { success = true, message = "Successfully login" });
                }
                else
                {               
                    return Json(new { success = true, message = "Successfully login" });
                }
            }
            else
            {            
                return Json(new { success = false, message = "Invalid user login or password. Please try again." }) ;
            }        

        }

     
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser objUser = new ApplicationUser()
                {
                    USER_NAME = registerVM.NAME,
                    Email = registerVM.EMAIL,
                    PhoneNumber = registerVM.PHONE_NUBMER,
                    NormalizedEmail = registerVM.EMAIL.ToUpper(),
                    EmailConfirmed = true,
                    UserName = registerVM.EMAIL,
                    CREATED_DATE = DateTime.Now,

                };

                if (registerVM.PASSWORD != registerVM.CONFIRM_PASSWORD)
                {              
                    return Json(new { success = false, message = "The password you entered did not matched." });
                }

                var objUserManager = await _UserManager.CreateAsync(objUser, registerVM.PASSWORD);

                if (objUserManager.Succeeded)
                {
                    if (!string.IsNullOrEmpty(registerVM.ROLE))
                    {
                        await _UserManager.AddToRoleAsync(objUser, registerVM.ROLE);
                    }
                    else
                    {
                        await _UserManager.AddToRoleAsync(objUser, SD.UserRole.CUSTOMER.ToString());
                    }

                    await _SignInManager.SignInAsync(objUser, isPersistent: false);

                    return Json(new { success = true, message = "Successfully registered" });
                }
                else
                {
                    return Json(new { success = false, message = "The email or password entered was invalid. Please try again." });
                }

            }

            return Json(new { success = true, message = "Successfully registered" });

        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _SignInManager.SignOutAsync();

            return Json(new { success = true, message = "Successfully logout" });

        }

        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}