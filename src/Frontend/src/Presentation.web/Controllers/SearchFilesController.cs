using BusinessLogic.core.UseCases;
using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Presentation.web.Controllers
{
    [Authorize]
    public class SearchFilesController : Controller
    {
        private IFolderUseCases _folderService;

        public SearchFilesController(IFolderUseCases folderService)
        {
            _folderService = folderService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ApplyFilters(string selectedValue)
        {
            return View("Files");
        }

        [HttpPost]
        public async Task<IActionResult> CreateFolder(FolderDto folder)
        {
            try
            {
                folder.UserId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                List<TagDto>? tags = JsonSerializer.Deserialize<List<TagDto>>(folder.Taglist);
                folder.FolderId = await _folderService.CreateFolder(folder, tags);
                return RedirectToAction("Index", "SearchFiles");
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
