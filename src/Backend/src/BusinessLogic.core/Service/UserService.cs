using AutoMapper;
using BusinessLogic.core.UseCases;
using DataAccess.Abstractions.Models;
using DataAccess.Abstractions.Repositories.Specific;
using DataAccess.Abstractions.UoW;
using DataAccess.SqlServer.Models;
using DomainModel;
using DTOs;
using Microsoft.IdentityModel.Tokens;

namespace BusinessLogic.core.Service
{
    public class UserService : IUserUseCases
    {
        #region Private Variable

        private readonly IRepositoriesManager _repositoriesManager;
        private readonly IMapper _mapper;
        private IUser _user;
        private IMembership _membership;

        #endregion

        #region Constructor
        public UserService(IRepositoriesManager repositoriesManager, IMapper mapper, IUser user, IMembership membership)
        {
            _repositoriesManager = repositoriesManager;
            _mapper = mapper;
            _user = user;
            _membership = membership;
        }

        #endregion

        #region CRUD Method

        public async Task<int> RegisterAsync(UserDto userDto)
        {
            try
            {
                // Mapeo de DTO (UserDto) a DomainModel (UserDomainModel)
                UserDomainModel userDomainModel = _mapper.Map<UserDomainModel>(userDto);

                // Mapeo de DomainModel a DataModel (User)
                _user.Nickname = userDomainModel.Nickname;
                _user.Email = userDomainModel.Email;
                _user.Password = userDomainModel.Password;

                _user.UserId = await _repositoriesManager.Users.CreateAsync(_user);
                await _repositoriesManager.CommitAsync();

                return _user.UserId;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while register the user");
            }

        }
        public async Task UpdateAccountAsync(UserDto userDto)
        {
            try
            {
                // Mapeo de DomainModel a DataModel (User)
                UserDomainModel userDomainModel = _mapper.Map<UserDomainModel>(userDto);

                _user = await _repositoriesManager.Users.GetUserByEmailAsync(userDomainModel.Email);
                _user.Nickname = (userDomainModel.Nickname.IsNullOrEmpty()) ? _user.Nickname : userDomainModel.Nickname;
                _user.Password = (userDomainModel.Password.IsNullOrEmpty()) ? _user.Password : userDomainModel.Password;

                await _repositoriesManager.Users.UpdateAsync(_user);
                await _repositoriesManager.CommitAsync();
            }
            catch (Exception ex) 
            {
                throw new Exception("An error occurred while updating the user");
            }
        }

        public async Task DeleteAccountAsync(int id)
        {
            try
            {
                await _repositoriesManager.Users.DeleteAsync(id);
                await _repositoriesManager.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the user", ex);
            }
        }

        #endregion

        public async Task<UserDto> LoginAsync(UserDto userDto)
        {
            try
            {
                UserDomainModel userDomainModel = _mapper.Map<UserDomainModel>(userDto);

                bool isCorrectCredentials = await _repositoriesManager.Users.AuthenticateUserAsync(userDomainModel.Email, userDomainModel.Password);

                if (isCorrectCredentials)
                {
                    if (userDomainModel.UserId != 0)
                    {
                        _user = await _repositoriesManager.Users.GetByIdAsync(userDomainModel.UserId);

                    }
                    else
                    {
                        _user = await _repositoriesManager.Users.GetUserByEmailAsync(userDomainModel.Email);
                    }
                }
                else
                {
                    bool isCorrectEmail = await _repositoriesManager.Users.VerifyUserByEmailAsync(userDomainModel.Email);

                    if (!isCorrectEmail)
                    {
                        throw new Exception("This user's email address is not registered yet.");
                    }

                    throw new Exception("the password is incorrect.");
                }

                _membership = await _repositoriesManager.Memberships.GetByIdAsync(_user.MembershipId);

                userDomainModel.UserId = _user.UserId;
                userDomainModel.Nickname = _user.Nickname;
                userDomainModel.Email = _user.Email;
                userDomainModel.Membership = _membership.MembershipName;
                userDomainModel.ProfilePictureURL = _user.ProfilePictureUrl;

                return _mapper.Map<UserDto>(userDomainModel);
            }
            catch (Exception ex) 
            {
                throw;
            }
        }

    }
}
