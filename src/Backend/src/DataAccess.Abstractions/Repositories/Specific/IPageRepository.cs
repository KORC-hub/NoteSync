using DataAccess.Abstractions.Repositories.Generic;

namespace DataAccess.Abstractions.Repositories.Specific
{
    public interface IPageRepository<T> : ICreateRepository<T>, IUpdateRepository<T>, IDeleteRepository<T>, IListRepository<T> 
    {

    }
}
