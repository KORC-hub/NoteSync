﻿using Microsoft.AspNetCore.Mvc;
using Presentation.web.Models.ViewModels;
// layers

// Authentication
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using BusinessLogic.core.UseCases;
using DTOs;


namespace Presentation.web.Controllers
{
    public class AccessController : Controller
    {

        #region Private Variable

        private IUserUseCases _userService;

        #endregion

        #region Constructors

        public AccessController(IUserUseCases userService)
        {
            _userService = userService;
        }

        #endregion

        #region Register methods

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserDto user)
        {
            if (user.Password != user.ConfirmPassword)
            {
                ViewData["Message"] = "la contraseña no coincide";
                return View();
            }

            try
            {
                await _userService.RegisterAsync(user);
                return RedirectToAction(nameof(Login));
            }
            catch(Exception ex) 
            { 
                ViewData["Message"] = ex.Message;
                return View();
            }
        }

        #endregion

        #region Login methods

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserDto user)
        {
            try
            {
                user = await _userService.LoginAsync(user);
                user.Membership = "basic";
                user.ProfilePictureURL = "";
            }
            catch (Exception ex) 
            {
                ViewData["Message"] = ex.Message;
                return View();
            }

            await Authentication(user);

            return RedirectToAction("Index","Home");
        }

        public async Task Authentication(UserDto user) 
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Nickname),
                new Claim("ProfilePictureURL", user.ProfilePictureURL),
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
                );
        }

        #endregion
    }
}
