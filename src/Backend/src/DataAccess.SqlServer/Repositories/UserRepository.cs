using AutoMapper;
using DataAccess.Abstractions.Models;
using DataAccess.Abstractions.Repositories.Specific;
using DataAccess.SqlServer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.SqlServer.Repositories
{
    public class UserRepository : IUserRepository<IUser>
    {
        private readonly NoteSyncDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(NoteSyncDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region CRUD

        public async Task<IUser> GetByIdAsync(int id)
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
        public async Task<IUser> GetUserByEmailAsync(string email)
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
                throw new Exception("An error occurred while retrieving the user by email from the database.", ex);
            }
        }


        public async Task CreateAsync(IUser user)
        {
            try
            {
                User userDataModel = _mapper.Map<User>(user);

                await _context.Users.AddAsync(userDataModel);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred when trying to add the user to the database.", ex);
            }
        }

        public async Task UpdateAsync(IUser user)
        {
            try
            {
                User? userDataModel = _context.Users.Local.FirstOrDefault(e => e.Email == user.Email);
                if (userDataModel != null)
                {
                    userDataModel.Nickname = user.Nickname;
                    userDataModel.Password = user.Password;
                } 
                else
                { 
                    userDataModel = _mapper.Map<User>(user);
                    _context.Attach(userDataModel);
                    _context.Entry(userDataModel).Property(p => p.Nickname).IsModified = true;
                    _context.Entry(userDataModel).Property(p => p.Password).IsModified = true;
                }

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
                User user = new User { UserId = id};
                _context.Users.Remove(user);

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
