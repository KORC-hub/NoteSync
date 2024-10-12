using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.core.UseCases
{
    public interface IUserUseCases
    {
        Task RegisterAsync(UserDto userDto);
        Task<UserDto> UpdateDataAsync(UserDto userDto);
        Task DeleteAccountAsync(UserDto userDto);
        Task<UserDto> LoginAsync(UserDto userDto);
    }
}
