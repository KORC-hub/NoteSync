using BusinessLogic.core.UseCases;
using DTOs;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using DataAccess.SqlServer.Models;

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
            try
            {
                userSession.Email = User.FindFirst(ClaimTypes.Email)?.Value;
                userSession.Nickname = User.FindFirst(ClaimTypes.Name)?.Value;
                userSession.ProfilePictureURL = User.FindFirst("ProfilePictureURL")?.Value;

                ViewBag.User = userSession;
                return View();
            }
            catch (Exception ex) 
            {
                return RedirectToAction("Index", "Home");
            }
            
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
                //throw new Exception("the user could not be deleted", ex);
                return RedirectToAction("Index", "UserSettings");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserDto user)
        {
            try
            {
                await _userService.UpdateAccountAsync(user);

                if (user.Nickname != null)
                {
                    await UpdateNicknameClaim(user.Nickname);
                }

                return RedirectToAction("Index", "UserSettings");
            }
            catch (Exception ex) 
            {
                return RedirectToAction("Index", "UserSettings");
            }
        }


        public async Task UpdateNicknameClaim(string newNickname) 
        {
            try
            {
                var UserIdentity = User.Identity as ClaimsIdentity;
                if (UserIdentity != null)
                {
                    var claims = User.Claims.ToList();

                    var ExistentClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);

                    if (ExistentClaim != null)
                    {
                        claims.Remove(ExistentClaim);
                    }

                    claims.Add(new Claim(ClaimTypes.Name, newNickname));

                    var NewIdentity = new ClaimsIdentity(claims, UserIdentity.AuthenticationType);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(NewIdentity)
                    );
                }
            }
            catch (Exception ex) 
            {
                throw new Exception("An error occurred, please try again later.", ex);
            }

        }


    }
}
