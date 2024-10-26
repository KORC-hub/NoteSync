using DTOs;

namespace BusinessLogic.core.UseCases
{
    public interface IUserUseCases
    {
        Task<int> RegisterAsync(UserDto userDto);
        Task UpdateAccountAsync(UserDto userDto);
        Task DeleteAccountAsync(int id);
        Task<UserDto> LoginAsync(UserDto userDto);
    }
}
