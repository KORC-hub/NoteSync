using API.core.Models;
using BusinessLogic.core.UseCases;
using DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class foldersController : ControllerBase
    {

        private IFolderUseCases _folderService;

        public foldersController(IFolderUseCases folderService)
        {
            _folderService = folderService;
        }

        // GET api/<foldersController>/UserId
        [HttpGet("{userId}")]
        public async Task<ActionResult<FolderDto>> Get(int userId)
        {
            List<FolderDto> folders = new List<FolderDto>();
            folders = await _folderService.GetAllFoldersAsync(userId);
            return Ok(folders);
        }

        [HttpPost]
        public async Task<ActionResult<FolderDto>> Post(FolderVM folder)
        {
            try
            {
                FolderDto newfolder = new FolderDto();
                newfolder.FolderName = folder.FolderName;
                newfolder.UserId = folder.UserId;
                newfolder.Tags = new List<TagDto>();
                newfolder.FolderId = await _folderService.CreateFolder(newfolder);
                return Ok(newfolder.FolderId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }

}
