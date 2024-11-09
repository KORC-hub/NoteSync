using Microsoft.AspNetCore.Mvc;

namespace Presentation.web.Controllers
{
    public class PageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
