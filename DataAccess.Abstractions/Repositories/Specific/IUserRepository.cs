using DataAccess.Abstractions.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstractions.Repositories.Specific
{
    public interface IUserRepository<T> : ICreateRepository<T>, IUpdateRepository<T>, IDeleteRepository<T>, IReadRepository<T>
    {
        void GetByEmail(ref T entity);
    }
}
