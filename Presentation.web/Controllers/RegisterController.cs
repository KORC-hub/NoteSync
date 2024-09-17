using Entities;
using BusinessLogic.core;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;


namespace Presentation.web.Controllers
{
    public class RegisterController : Controller
    {
        #region Private Varieble

        private UserBusinessLogic _userBusinessLogic = new UserBusinessLogic();

        public IActionResult Index()
        {
            return View();
        }

        #endregion

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            user = new User()
            {
                Nickname = user.Nickname,
                Email = user.Email,
                Password = user.Password,
            };

            _userBusinessLogic.Create(ref user);

            return View("~/Views/Auth/Login.cshtml");
        }

    }
}
