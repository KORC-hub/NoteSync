using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.web.Controllers
{
    [Authorize]
    public class PageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
