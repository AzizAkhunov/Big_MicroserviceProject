using OLX.Domain.DTOs;
using OLX.Domain.Entities;

namespace OLX.Application.Interfaces
{
    public interface IUserService
    {
        ValueTask<ICollection<User>> GetAllUserAsync();
        ValueTask<bool> CreateUserAsync(UsersDTO userDTO);
        ValueTask<bool> DeleteUserAsync(int id);
        ValueTask<bool> UpdateUserAsync(int id, UsersDTO userDTO);
        ValueTask<User> GetUserById(int id);
    }
}
