using Microsoft.AspNetCore.Mvc;
using Presentation.web.Models;
using System.Diagnostics;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Entities;
using BusinessLogic.core;


namespace Presentation.web.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        #region Private variable

        private UserAuthentication _userBusinessLogic = new UserAuthentication();
        private User userSession = new User();

        #endregion

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Files()
        {
            return View();
        }
        public IActionResult UserSettings()
        {
            userSession.UserId = Convert.ToUInt32(User.FindFirst("Id")?.Value);

            _userBusinessLogic.Read(ref userSession);
            ViewBag.User = userSession;
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Landing");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
