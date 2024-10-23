using DTOs;

namespace BusinessLogic.core.UseCases
{
    public interface IUserUseCases
    {
        Task RegisterAsync(UserDto userDto);
        Task<UserDto> UpdateDataAsync(UserDto userDto);
        Task DeleteAccountAsync(int id);
        Task<UserDto> LoginAsync(UserDto userDto);
    }
}
