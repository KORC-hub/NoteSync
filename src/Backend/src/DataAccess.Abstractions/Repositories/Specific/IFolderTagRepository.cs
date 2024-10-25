using DataAccess.Abstractions.Repositories.Generic;

namespace DataAccess.Abstractions.Repositories.Specific
{
    public interface IFolderTagRepository<T> : ICreateRepository<T>, IDeleteRepository<T>, IListRepository<T>
    {
    }
}
