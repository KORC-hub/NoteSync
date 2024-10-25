using DataAccess.Abstractions.Models;
using DataAccess.Abstractions.Repositories.Specific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstractions.UoW
{
    public interface IRepositoriesManager : IDisposable
    {
        //These repositories represent collections of entities
        IUserRepository<IUser> Users { get; }
        IMembershipRepository<IMembership> Memberships { get; }
        ITagRepository<ITag> Tags { get; }
        IFolderRepository<IFolder> Folders { get; }
        IFolderTagRepository<IFolderTag> FolderTags { get; }
        IPageRepository<IPage> Pages { get; }

        Task<int> CommitAsync();
    }
}
