using DataAccess.Abstractions.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstractions.Repositories.Specific
{
    public interface IFileRepository<T> : ICreateRepository<T>, IUpdateRepository<T>, IDeleteRepository<T>, IReadRepository<T>, IListRepository<T>    
    {

    }
}
