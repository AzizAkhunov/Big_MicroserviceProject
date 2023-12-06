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
        ValueTask<User> GetUsersProducts(int id);
        ValueTask<User> GetUsersBuys(int id);
        ValueTask<User> GetUsersCards(int id);

    }
}
