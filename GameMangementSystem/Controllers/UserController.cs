using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using GameMangementSystem.Models;
using GameMangementSystem.Context;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
namespace GameMangementSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly GameContext _context;

        public UserController(GameContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Username,Password")] Users user)
        {
            //verify here
            var us = from u in _context.Users select u;
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
                await HttpContext.SignInAsync( new ClaimsPrincipal(claimsIdentity), authProperties);
              
                return Redirect("/Games/Index");
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
            await HttpContext.SignOutAsync();
           return Redirect("/User/LogoutSuccess");
        }
        public IActionResult LogoutSuccess()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Username,Password")] Users user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Login));
            }
            return View(user);
        }
        public IActionResult Register()
        {
            return View();
        }

    }
}