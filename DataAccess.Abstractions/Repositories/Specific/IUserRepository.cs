using DataAccess.Abstractions.Repositories.Generic;

namespace DataAccess.Abstractions.Repositories.Specific
{
    public interface IUserRepository<T> : ICreateRepository<T>, IUpdateRepository<T>, IDeleteRepository<T>, IReadRepository<T>
    {
        Task<T?> UserByEmailAsync(string email);
        Task<T?> AuthenticateUserAsync(T model);
    }
}
