﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GdmStore.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using GdmStore.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;

namespace GdmStore.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private DataContext _context;
        public AccountController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(user);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин или пароль");
            }
            return View(model);
        }


        private async Task Authenticate(User user)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        //[HttpGet]
        //public IActionResult Register()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
        //        if (user == null)
        //        {

        //            user = new User { Email = model.Email, Password = model.Password };
        //            Role userRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "user");
        //            if (userRole != null)
        //                user.Role = userRole;

        //            _context.Users.Add(user);
        //            await _context.SaveChangesAsync();

        //            await Authenticate(user); 

        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //            ModelState.AddModelError("", "Некорректные логин и(или) пароль");
        //    }
        //    return View(model);
        //}
    }
}
       



