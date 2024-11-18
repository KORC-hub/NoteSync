using Microsoft.AspNetCore.Mvc;
using Presentation.web.Models.ViewModels;
// layers

// Authentication
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using BusinessLogic.core.UseCases;
using DTOs;
using BusinessLogic.core.Service;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text;
using System.Security.Cryptography;


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

        public IActionResult Index()
        {
            ViewData["Message"] = TempData["ErrorMessage"];
            return View();
        }

        #region Register methods

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserDto user)
        {
            try
            {
                user.Email = ConvertirToSha256(user.Email);
                user.Password = ConvertirToSha256(user.Password);
                user.UserId = Convert.ToString(await _userService.RegisterAsync(user));
                return await Login(user);
            }
            catch(Exception ex) 
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index", "Access");
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

                if (user.UserId is null)
                {
                    user.Email = ConvertirToSha256(user.Email);
                    user.Password = ConvertirToSha256(user.Password);
                }

                user = await _userService.LoginAsync(user);
                user.ProfilePictureURL = "";

                await Authentication(user);

                return RedirectToAction("Index", "Folders");

            }
            catch (Exception ex) 
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index", "Access");
            }
        }

        public async Task Authentication(UserDto user) 
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("Id", user.UserId),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Nickname),
                new Claim("Membership", user.Membership),
                new Claim("ProfilePictureURL", user.ProfilePictureURL),
            };

            try
            {
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                };
                await HttpContext.SignInAsync( CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity),properties);
            }
            catch (Exception ex) 
            {
                throw new Exception("An error occurred, please try again later.",ex);
            }
        }

        #endregion

        public static string ConvertirToSha256(string texto)
        {
            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256.Create())
            {
                Encoding encoding = Encoding.UTF8;
                byte[] result = hash.ComputeHash(encoding.GetBytes(texto));
                foreach (byte b in result)
                {
                    Sb.Append(b.ToString("x2"));
                }
            }
            return Sb.ToString();
        }

    }
}
