﻿using AutoMapper;
using DataAccess.Abstractions.Models;
using DataAccess.Abstractions.Repositories.Specific;
using DataAccess.SqlServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SqlServer.Repositories
{
    public class FolderTagRepository : IFolderTagRepository<IFolderTag>
    {
        private readonly NoteSyncDbContext _context;
        private readonly IMapper _mapper;

        public FolderTagRepository(NoteSyncDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<int>> GetAllByFolderAsync(int folderId)
        {
            List<FolderTag> foldersTagFromDataBase = await _context.FolderTags
           .Where(folderTag => folderTag.FolderId == folderId)
           .ToListAsync();

            List<int> foldersTag = new List<int>();

            foreach (FolderTag folderTag in foldersTagFromDataBase)
            {
                foldersTag.Add(folderTag.TagId);
            }

            return foldersTag;
        }
        public Task<List<int>> GetAllByTagAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CreateAsync(IFolderTag folderTag)
        {
            try
            {
                FolderTag folderTagDataModel = _mapper.Map<FolderTag>(folderTag);
                await _context.FolderTags.AddAsync(folderTagDataModel);
                return folderTagDataModel.Id;

            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred when trying to add the relation between folder and tag to the database.", ex);
            }
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}
