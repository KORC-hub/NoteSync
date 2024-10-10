using BusinessLogic.core;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.web.Controllers
{
    public class UserSettingsController : Controller
    {
        private UserAuthentication _userAuthentication = new UserAuthentication();
        private User userSession = new User();

        public IActionResult Index()
        {
            userSession.UserId = Convert.ToUInt32(User.FindFirst("Id")?.Value);

            _userAuthentication.GetById(ref userSession);
            ViewBag.User = userSession;
            return View();
        }

        public IActionResult UpdateUser()
        {
        
            //if (user.ErrorMessage == null)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            return View();
        }

    }
}
