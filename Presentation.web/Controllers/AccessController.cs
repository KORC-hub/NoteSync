using Microsoft.AspNetCore.Mvc;
using Presentation.web.Models.ViewModels;
// layers
using BusinessLogic.core;
using Entities;
// Authentication
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;


namespace Presentation.web.Controllers
{
    public class AccessController : Controller
    {

        #region Private Variable

        private UserAuthentication _userAuthentication = new UserAuthentication();
        private User user = new User();

        #endregion

        #region Register methods

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterVM model)
        {

            if (model.Password != model.ConfirmPassword)
            {
                ViewData["Message"] = "la contraseña no coincide";
                return View();
            }

            User user = new User()
            {
                Nickname = model.Nickname,
                Email = model.Email,
                Password = model.Password,
            };

            _userAuthentication.Create(ref user);


            if (user.ErrorMessage == null)
            {
                return RedirectToAction(nameof(Login));
            }

            ViewData["Message"] = "No se pudo crear el usuario por un error: " + user.ErrorMessage;
            return View();

        }

        #endregion

        #region Login methods

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            user.Email = model.Email;
            user.Password = model.Password;

            if (!_userAuthentication.Login(ref user))
            {
                ViewData["Message"] = user.ErrorMessage;
                return View();
            }

            Authentication(user);

            return RedirectToAction("Index","Home");
        }

        public async void Authentication(User user) 
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Nickname),
                new Claim("Id", user.UserId.ToString()),
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
