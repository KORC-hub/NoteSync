using Microsoft.AspNetCore.Mvc;

namespace Presentation.web.Controllers
{
    public class SearchFilesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ApplyFilters(string selectedValue)
        {
            return View("Files");
        }

    }
}
