using DataAccess.Abstractions.Models;
using DataAccess.Abstractions.Repositories.Specific;
using DataAccess.Abstractions.UoW;

namespace DataAccess.SqlServer
{
    public class RepositoriesManager : IRepositoriesManager
    {
        private readonly NoteSyncDbContext _context;
        public IUserRepository<IUser> Users { get; private set; }
        public IMembershipRepository<IMembership> Memberships { get; private set; }
        public ITagRepository<ITag> Tags { get; private set; }
        public IFolderRepository<IFolder> Folders { get; private set; }
        public IFolderTagRepository<IFolderTag> FolderTags { get; private set; }
        public IPageRepository<IPage> Pages { get; private set; }

        public RepositoriesManager(NoteSyncDbContext context,
                                   IUserRepository<IUser> users,
                                   IMembershipRepository<IMembership> memberships,
                                   ITagRepository<ITag> tags, IFolderRepository<IFolder> folders,
                                   IFolderTagRepository<IFolderTag> folderTags,
                                   IPageRepository<IPage> pages)
        {
            _context = context;
            Users = users;
            Memberships = memberships;
            Tags = tags;
            Folders = folders;
            FolderTags = folderTags;
            Pages = pages;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
