using Microsoft.AspNetCore.Mvc;

namespace Presentation.web.Controllers
{
    public class LandingController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity!.IsAuthenticated) 
            {
                return RedirectToAction("Index","Home");
            }

            return View();
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
