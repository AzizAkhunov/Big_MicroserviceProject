using OLX.Domain.DTOs;
using OLX.Domain.Entities;

namespace OLX.Application.Interfaces
{
    public interface IUserService
    {
        ValueTask<bool> CreateUserAsync(UserDTO userDTO);
        ValueTask<ICollection<User>> GetAllUsersAsync();
        ValueTask<User> GetUserByIdAsync(int id);
        ValueTask<bool> DeleteUserByIdAsync(int id);
        ValueTask<bool> UpdateUserAsync(int id, UserDTO userDTO);
    }
}
