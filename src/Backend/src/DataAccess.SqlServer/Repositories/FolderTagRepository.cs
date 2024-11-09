using AutoMapper;
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

        public async Task<List<int[]>> GetAllByFolderAsync(int folderId)
        {
            try
            {
                List<FolderTag> foldersTagFromDataBase = await _context.FolderTags
                .Where(folderTag => folderTag.FolderId == folderId)
                .ToListAsync();

                List<int[]> FolderTagIds = new List<int[]>();

                foreach (FolderTag folderTag in foldersTagFromDataBase)
                {
                    int[] ids = { folderTag.FolderTagId, folderTag.FolderId,folderTag.TagId };

                    FolderTagIds.Add(ids);
                }

                return FolderTagIds;
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred when trying to find FolderTagId to the database.", ex);
            }
        }

        public async Task<List<int>> GetAllTagIdByFolderAsync(int folderId)
        {
            try
            {
                List<FolderTag> foldersTagFromDataBase = await _context.FolderTags
                .Where(folderTag => folderTag.FolderId == folderId)
                .ToListAsync();

                List<int> folderTags = new List<int>();

                foreach (FolderTag folderTag in foldersTagFromDataBase)
                {
                    folderTags.Add(folderTag.TagId);
                }

                return folderTags;
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred when trying to find tags id from folderTag table to the database.", ex);
            }

        }
        public async Task<List<int>> GetAllFolderIdByTagAsync(int tagId)
        {
            try
            {
                List<FolderTag> foldersTagFromDataBase = await _context.FolderTags
                .Where(folderTag => folderTag.TagId == tagId)
                .ToListAsync();

                List<int> foldersTag = new List<int>();

                foreach (FolderTag folderTag in foldersTagFromDataBase)
                {
                    foldersTag.Add(folderTag.FolderId);
                }

                return foldersTag;
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred when trying to find folder id from folderTag table to the database.", ex);
            }
        }

        public async Task<int> CreateAsync(IFolderTag folderTag)
        {
            try
            {
                FolderTag folderTagDataModel = _mapper.Map<FolderTag>(folderTag);
                await _context.FolderTags.AddAsync(folderTagDataModel);
                return folderTagDataModel.FolderTagId;

            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred when trying to add the relation between folder and tag to the database.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                FolderTag folderTag = await _context.FolderTags.FindAsync(id);
                if (folderTag != null) 
                { 
                    _context.FolderTags.Remove(folderTag);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("The relation folderTag could not be deleted from database", ex);
            }
        }

    }
}
