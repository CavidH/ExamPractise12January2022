using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamPractise12January2022.Models;
using ExamPractise12January2022.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace ExamPractise12January2022.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> _userManager { get; }
        private SignInManager<User> _signInManager { get; }

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        //[HttpPost]  
        //public async Task<IActionResult> Register(RegisterVM model)  
        //{  
        //    if (ModelState.IsValid)  
        //    {  
        //        var user = new IdentityUser   
        //        {   
        //            UserName=model.Email,  
        //            Email=model.Email  
        //        };  
        //        var result = await _userManager.CreateAsync(user, model.Password);  
  
        //        if (result.Succeeded)  
        //        {  
        //            await _signInManager.SignInAsync(user, isPersistent: false);  
        //            return RedirectToAction("Index", "Home");  
        //        }  
        //        foreach (var error in result.Errors)  
        //        {  
        //            ModelState.AddModelError("",error.Description);  
        //        }  
        //    }  
        //    return View();  
        //} 
    }
}