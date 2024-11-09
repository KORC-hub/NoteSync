using AutoMapper;
using DataAccess.Abstractions.Models;
using DataAccess.Abstractions.Repositories.Specific;
using DataAccess.SqlServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace DataAccess.SqlServer.Repositories
{
    public class FolderRepository : IFolderRepository<IFolder>
    {
        private readonly NoteSyncDbContext _context;
        private readonly IMapper _mapper;

        public FolderRepository(NoteSyncDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IFolder> GetByIdAsync(int id)
        {
            try
            {
                Folder? folder = await _context.Folders.FindAsync(id);

                if (folder == null)
                {
                    throw new Exception();
                }

                return folder;

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the folder with id="+ id +" from the database.", ex);
            }
        }

        public async Task<List<IFolder>> GetAllAsync(int userId)
        {
            try
            {
                List<Folder> foldersFromDataBase = await _context.Folders
                   .Where(folder => folder.UserId == userId)
                   .ToListAsync();

                List<IFolder> folders = new List<IFolder>();

                foreach (Folder folder in foldersFromDataBase)
                {
                    folders.Add(folder);
                }

                return folders;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> CreateAsync(IFolder folder)
        {
            try
            {
                Folder folderDataModel = _mapper.Map<Folder>(folder);
                await _context.Folders.AddAsync(folderDataModel);
                await _context.SaveChangesAsync();
                return folderDataModel.FolderId;
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred when trying to add the folder to the database.", ex);
            }
        }

        public async Task UpdateAsync(IFolder folder)
        {
            try
            {
                Folder? folderDataModel = _context.Folders.Local.FirstOrDefault(e => e.FolderId == folder.FolderId);
                if (folderDataModel != null)
                {
                    folderDataModel.FolderName = folder.FolderName;
                    folderDataModel.LastModifiedDate = folder.LastModifiedDate;
                }
                else
                {
                    folderDataModel = _mapper.Map<Folder>(folder);
                    _context.Attach(folderDataModel);
                    _context.Entry(folderDataModel).Property(p => p.FolderName).IsModified = true;
                    _context.Entry(folderDataModel).Property(p => p.LastModifiedDate).IsModified = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Could not update folder from database", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                Folder folder = await _context.Folders.FindAsync(id);
                if (folder != null)
                {
                    _context.Folders.Remove(folder);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Folder could not be deleted from database", ex);
            }
        }

    }
}
