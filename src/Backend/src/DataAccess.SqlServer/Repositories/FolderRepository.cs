using AutoMapper;
using DataAccess.Abstractions.Models;
using DataAccess.Abstractions.Repositories.Specific;
using DataAccess.SqlServer.Models;

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

        public Task<IFolder> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IFolder>> GetAllAsync()
        {
            throw new NotImplementedException();
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

        public Task UpdateAsync(IFolder model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}
