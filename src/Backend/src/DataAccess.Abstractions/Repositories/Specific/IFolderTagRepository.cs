using DataAccess.Abstractions.Repositories.Generic;
using System.Threading.Tasks;

namespace DataAccess.Abstractions.Repositories.Specific
{
    public interface IFolderTagRepository<T> : ICreateRepository<T>, IDeleteRepository<T>
    {
        Task<List<int>> GetAllByFolderAsync(int id);
        Task<List<int>> GetAllByTagAsync(int id);
    }
}
