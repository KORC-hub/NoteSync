using BusinessLogic.core.UseCases;
using DTOs;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Presentation.web.Controllers
{
    [Authorize]
    public class UserSettingsController : Controller
    {
        private IUserUseCases _userService;
        private UserDto userSession = new UserDto();

        public UserSettingsController(IUserUseCases userService)
        {
            _userService = userService;
        }


        public IActionResult Index()
        {
            userSession.Email = User.FindFirst(ClaimTypes.Email)?.Value;
            userSession.Nickname = User.FindFirst(ClaimTypes.Name)?.Value;
            userSession.ProfilePictureURL = User.FindFirst("ProfilePictureURL")?.Value;

            ViewBag.User = userSession;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser() 
        {
            try
            {
                await _userService.DeleteAccountAsync(Convert.ToInt32(User.FindFirst("Id")?.Value));
                return RedirectToAction("Logout", "Home");
            }
            catch (Exception ex)
            {
                throw new Exception("the user could not be deleted", ex);
            }
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
