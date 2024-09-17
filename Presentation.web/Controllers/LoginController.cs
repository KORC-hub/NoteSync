using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Presentation.web.Models.DTOs;
using Presentation.web.Models.VOs;

namespace Presentation.web.Controllers
{
    public class LoginController : Controller
    {
        private const string LoginForm = "login-form";

        [SupplyParameterFromForm(FormName = LoginForm)]
        private LoginUserDTO LoginUser { get; set; } = new();

        [CascadingParameter]
        public HttpContext HttpContext { get; set; }

        public int MyProperty { get; set; }

        private async Task LoginUserAsync() 
        {
            // validate email and passwird user
            await Task.Delay(2000);

            //await HttpContext.SignInAsync()

            LoggedInUserVO User = new LoggedInUserVO(1,"","");

        }

    }
}
