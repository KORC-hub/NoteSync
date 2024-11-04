﻿using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.core.UseCases
{
    public interface IFolderUseCases
    {
        Task<List<FolderDto>> GetAllFoldersAsync(int UserId);
        Task<List<TagDto>> GetAllTagsAsync(int UserId);
        Task<int> CreateFolder(FolderDto folder, List<TagDto>? tags);
        Task UpdateFolder(FolderDto folder);
        Task DeleteFolder(int id);
    }
}