using BusinessLogic.core.UseCases;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Presentation.web.Controllers
{
    public class UserSettingsController : Controller
    {
        private IUserUseCases _userService;
        private UserDto userSession = new UserDto();

        public IActionResult Index()
        {
            userSession.Email = User.FindFirst(ClaimTypes.Email)?.Value;
            userSession.Nickname = User.FindFirst(ClaimTypes.Name)?.Value;
            userSession.ProfilePictureURL = User.FindFirst("ProfilePictureURL")?.Value;

            ViewBag.User = userSession;
            return View();
        }

        //public IActionResult UpdateUser()
        //{

        //    //if (user.ErrorMessage == null)
        //    //{
        //    //    return RedirectToAction("Index", "Home");
        //    //}
        //    return View();
        //}

    }
}
