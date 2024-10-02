using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstractions.Repositories.Generic
{
    public interface IUpdateRepository<T>
    {
        void Update(ref T entity);
    }
}
