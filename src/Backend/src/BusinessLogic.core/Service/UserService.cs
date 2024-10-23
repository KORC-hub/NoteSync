using AutoMapper;
using BusinessLogic.core.UseCases;
using DataAccess.Abstractions.Models;
using DataAccess.Abstractions.Repositories.Specific;
using DataAccess.SqlServer.Models;
using DomainModel;
using DTOs;

namespace BusinessLogic.core.Service
{
    public class UserService : IUserUseCases
    {
        #region Private Variable

        private readonly IUserRepository<User> _userRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor
        public UserService(IUserRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        #endregion

        #region CRUD Method

        public async Task RegisterAsync(UserDto userDto)
        {
            // Mapeo de DTO (UserDto) a DomainModel (UserDomainModel)
            UserDomainModel userDomainModel = _mapper.Map<UserDomainModel>(userDto);

            // Mapeo de DomainModel a DataModel (User)
            User _user = _mapper.Map<User>(userDomainModel);

            await _userRepository.CreateAsync(_user);
        }
        public async Task<UserDto> UpdateDataAsync(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAccountAsync(int id)
        {
            try
            {
                await _userRepository.DeleteAsync(id);
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
                User user = null;
                
                bool isCorrectCredentials = await _userRepository.AuthenticateUserAsync(userDomainModel.Email, userDomainModel.Password);

                if (isCorrectCredentials) 
                {
                    user = await _userRepository.GetUserByEmailAsync(userDomainModel.Email);
                }
                else
                {
                    bool isCorrectEmail = await _userRepository.VerifyUserByEmailAsync(userDomainModel.Email);

                    if (!isCorrectEmail)
                    {
                        throw new Exception("This user's email address is not registered yet.");
                    }

                    throw new Exception("the password is incorrect.");
                }

                userDomainModel = _mapper.Map<UserDomainModel>(user);

                return _mapper.Map<UserDto>(userDomainModel);
            }
            catch (Exception ex) 
            {
                throw;
            }
        }

    }
}
