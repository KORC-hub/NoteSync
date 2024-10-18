using DataAccess.Abstractions.Repositories.Specific;
using DataAccess.SqlServer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.SqlServer.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly NoteSyncDbContext _context;

        public UserRepository(NoteSyncDbContext context)
        {
            _context = context;
        }

        #region CRUD

        public async Task<User> GetByIdAsync(int id)
        {
            try
            {
                User? user = await _context.Users.FindAsync(id);

                if (user == null)
                {
                    throw new Exception("User not found");
                }
                return user;

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the user.", ex);
            }
        }

        public async Task CreateAsync(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred when trying to add the user.", ex);
            }
        }

        public async Task UpdateAsync(User model)
        {
            try
            {
                _context.Users.Update(model);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Could not update user", ex);
            }

        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                User user = await GetByIdAsync(id);
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("User could not be deleted", ex);
            }
        }

        #endregion

        #region Veridy Method
        public async Task<User?> UserByEmailAsync(string email)
        {
            try
            {
                var user = await _context.Users
                    .Where((u) => u.Email == email)
                    .FirstOrDefaultAsync();

                if (user == null)
                {
                    throw new Exception("This user's email address is not registered yet.");
                }
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("Error verifying the user by mail.", ex);
            }
        }
        public async Task<User?> AuthenticateUserAsync(User user)
        {
            try
            {
                var verifyUser = await UserByEmailAsync(user.Email);

                if (verifyUser.Password != user.Password)
                {
                    throw new Exception("The password is incorrect");
                }

                return verifyUser;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

    }
}
