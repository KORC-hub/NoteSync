using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstractions.Repositories.Generic
{
    public interface IListRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
    }
}
