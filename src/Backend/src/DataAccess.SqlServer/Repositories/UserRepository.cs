using DataAccess.Abstractions.Models;
using DataAccess.Abstractions.Repositories.Specific;
using DataAccess.SqlServer.Models;
using Microsoft.Data.SqlClient;
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
                    throw new Exception();
                }

                return user;

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the user from the database.", ex);
            }
        }       
        public async Task<User> GetUserByEmailAsync(string email)
        {
            try
            {
                User? user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

                if (user == null)
                {
                    throw new Exception();
                }

                return user;

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the user from the database.", ex);
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
                throw new Exception("An unexpected error occurred when trying to add the user to the database.", ex);
            }
        }

        public async Task UpdateAsync(User user)
        {
            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Could not update user from database", ex);
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
                throw new Exception("User could not be deleted from database", ex);
            }
        }

        #endregion

        #region Veridy Method
        public async Task<bool> VerifyUserByEmailAsync(string email)
        {
            try
            {
                bool exists = await _context.Users.AnyAsync(u => u.Email == email);

                return exists;

            }
            catch (Exception ex)
            {
                throw new Exception("Error when trying to verify user's email from database.");
            }
        }
        public async Task<bool> AuthenticateUserAsync(string email, string password)
        {
            try
            {
                bool exists = await _context.Users.AnyAsync(u => u.Email == email && u.Password == password);

                return exists;

            }
            catch (Exception ex)
            {
                throw new Exception("Error when trying to verify user from database.");
            }
        }

        #endregion

    }
}
