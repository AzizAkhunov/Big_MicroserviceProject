using Microsoft.EntityFrameworkCore;
using OLX.Application.Interfaces;
using OLX.Domain.DTOs;
using OLX.Domain.Entities;
using OLX.Infastructure.DbContexts;

namespace OLX.Application.Services
{
    public class UserService : IUserService
    {
        private readonly OLXDbContext _context;

        public UserService(OLXDbContext context)
        {
            _context = context;
        }

        public async ValueTask<bool> CreateUserAsync(UserDTO userDTO)
        {
            try
            {
                var user = new User()
                {
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    PhoneNumber = userDTO.PhoneNumber,
                    Country = userDTO.Country,
                };
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async ValueTask<bool> DeleteUserByIdAsync(int id)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
                if (user is not null)
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();

                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async ValueTask<ICollection<User>> GetAllUsersAsync()
        {
            var result = await _context.Users.ToListAsync();
            return result;
        }

        public async ValueTask<User> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }

        public async ValueTask<bool> UpdateUserAsync(int id, UserDTO userDTO)
        {
            try
            {
                var user = new User()
                {
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    PhoneNumber = userDTO.PhoneNumber,
                    Country = userDTO.Country,
                };
                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
