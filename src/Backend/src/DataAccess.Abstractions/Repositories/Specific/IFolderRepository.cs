using DataAccess.Abstractions.Repositories.Generic;


namespace DataAccess.Abstractions.Repositories.Specific
{
    public interface IFolderRepository<T> : ICreateRepository<T>, IUpdateRepository<T>, IDeleteRepository<T>, IReadRepository<T>, IListRepository<T>    
    {

    }
}
