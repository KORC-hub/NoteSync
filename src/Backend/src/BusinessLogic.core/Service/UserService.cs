using AutoMapper;
using BusinessLogic.core.UseCases;
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
            User user = _mapper.Map<User>(userDomainModel);

            await _userRepository.CreateAsync(user);
        }
        public async Task<UserDto> UpdateDataAsync(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAccountAsync(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        #endregion

        public async Task<UserDto> LoginAsync(UserDto userDto)
        {
            try
            {
                UserDomainModel userDomainModel = _mapper.Map<UserDomainModel>(userDto);

                User? user = _mapper.Map<User>(userDomainModel);

                user = await _userRepository.AuthenticateUserAsync(user);

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
