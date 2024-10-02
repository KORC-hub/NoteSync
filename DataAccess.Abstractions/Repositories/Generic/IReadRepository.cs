using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstractions.Repositories.Generic
{
    public interface IReadRepository<T>
    {
        void GetById(ref T entity);
    }
}
