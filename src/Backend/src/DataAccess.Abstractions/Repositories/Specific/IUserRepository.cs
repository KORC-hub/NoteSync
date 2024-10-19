using DataAccess.Abstractions.Models;
using DataAccess.Abstractions.Repositories.Generic;

namespace DataAccess.Abstractions.Repositories.Specific
{
    public interface IUserRepository<T> : ICreateRepository<T>, IUpdateRepository<T>, IDeleteRepository<T>, IReadRepository<T>
    {
        Task<T> GetUserByEmailAsync(string email);
        Task<bool> VerifyUserByEmailAsync(string email);
        Task<bool> AuthenticateUserAsync(string email, string password);
    }
}
