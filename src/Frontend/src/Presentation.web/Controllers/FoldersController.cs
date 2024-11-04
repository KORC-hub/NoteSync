﻿using BusinessLogic.core.UseCases;
using DTOs;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.web.Models.ViewModels;
using System.Text.Json;

namespace Presentation.web.Controllers
{
    [Authorize]
    public class FoldersController : Controller
    {
        private IFolderUseCases _folderService;

        public FoldersController(IFolderUseCases folderService)
        {
            _folderService = folderService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            int UserId = Convert.ToInt32(User.FindFirst("Id")?.Value);

            List<FolderDto> folders = new List<FolderDto>();
            folders = await _folderService.GetAllFoldersAsync(UserId);

            List<TagDto> tags = new List<TagDto>();
            tags = await _folderService.GetAllTagsAsync(UserId);

            FolderViewModel folderViewModel = new FolderViewModel(folders, tags);

            return View(folderViewModel);
        }

        [HttpPost]
        public IActionResult ApplyFilters(string selectedValue)
        {
            return View("Files");
        }

        [HttpPost]
        public async Task<IActionResult> CreateFolder(FolderViewModel folderViewModel)
        {
            try
            {
                FolderDto folder = new FolderDto();
                folder.FolderName = folderViewModel.FolderName;
                folder.UserId = Convert.ToInt32(User.FindFirst("Id")?.Value);
                List<TagDto>? tags = JsonSerializer.Deserialize<List<TagDto>>(folderViewModel.Taglist);
                folder.FolderId = await _folderService.CreateFolder(folder, tags);
                return RedirectToAction("Index", "Folders");
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

    }
}