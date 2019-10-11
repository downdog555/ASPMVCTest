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
    /// <summary>
    /// controller for user model
    /// </summary>
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
            //select all entries
            var us = from u in _context.Users select u;
            //search entries for where username and password is found
            us = us.Where(s => s.Username.Equals(user.Username)).Where(s => s.Password.Equals(user.Password));
            // if there is only one there we can authentiacre
            if (us.Count() == 1)
            {
                //create a list of claims claim
                //could add a roles claimtype to this to allow futher segregation
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username)
                };
                //create a claims identity
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                //set options
                //allowed to refersh the claim/cookie
                //also is persistant between multiple requressts.
                var authProperties = new AuthenticationProperties
                {
                   AllowRefresh =true,
                    IsPersistent = true
                };
                //signin uisng a claims principle and the options set
                await HttpContext.SignInAsync( new ClaimsPrincipal(claimsIdentity), authProperties);
              //thne reqiredct tothe games m ain page
                return Redirect("/Games/Index");
            }
            //if we do not find a user
            //load the view with the data previously entered but remove the password
            user.Password = "";
            return View(user);
        }
        /// <summary>
        /// display login view
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// only authorised users can logout
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            //logout
            await HttpContext.SignOutAsync();
            //then redirect to the logoutsucess view
           return Redirect("/User/LogoutSuccess");
        }
        /// <summary>
        /// load view
        /// </summary>
        /// <returns></returns>
        public IActionResult LogoutSuccess()
        {
            return View();
        }
        /// <summary>
        /// register post function
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Username,Password")] Users user)
        {
            //if model is valid
            if (ModelState.IsValid)
            {
                //add a new user
                _context.Add(user);
                // save the db changes
                await _context.SaveChangesAsync();
                //redirect to login page
                return RedirectToAction(nameof(Login));
            }
            //if not return to the view with entered data
            return View(user);
        }
        /// <summary>
        /// basic register function 
        /// loads view
        /// </summary>
        /// <returns></returns>
        public IActionResult Register()
        {
            return View();
        }

    }
}