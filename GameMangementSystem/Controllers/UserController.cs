﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GameMangementSystem.Models;
using GameMangementSystem.Context;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
namespace GameMangementSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly UserContext _userContext;

        public UserController(UserContext context)
        {
            _userContext = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Username,Password")] User user)
        {
            //verify here
            var us = from u in _userContext.User select u;
            us = us.Where(s => s.Username.Equals(user.Username)).Where(s => s.Password.Equals(user.Password));
            if (us.Count() == 1)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username)
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                   AllowRefresh =true,
                    IsPersistent = true
                };
                await HttpContext.SignInAsync( CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                return RedirectToAction();
            }
            user.Password = "";
            return View(user);
        }
        public IActionResult Login()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Username,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                _userContext.Add(user);
                await _userContext.SaveChangesAsync();
                return RedirectToAction();
            }
            return View(user);
        }
        public IActionResult Register()
        {
            return View();
        }

    }
}