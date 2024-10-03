using DataAccess.Abstractions.Repositories.Generic;

namespace DataAccess.Abstractions.Repositories.Specific
{
    public interface IUserRepository<T> : ICreateRepository<T>, IUpdateRepository<T>, IDeleteRepository<T>, IReadRepository<T>
    {
        bool VerifyUserByEmail(string email, string password);
        bool AuthenticateUser(ref T entity);
    }
}
