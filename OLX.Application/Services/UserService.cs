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

        public async ValueTask<bool> CreateUserAsync(UsersDTO userDTO)
        {
            try
            {
                var user = new User()
                {
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    PhoneNumber = userDTO.PhoneNumber,
                    Country = userDTO.Country
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

        public async ValueTask<bool> DeleteUserAsync(int id)
        {
            try
            {
                var result = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

                _context.Users.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async ValueTask<ICollection<User>> GetAllUserAsync()
        {
            var result = await _context.Users.Include(x => x.Cards).Include(x => x.Buys).Include(x => x.Products).ToListAsync();
            return result;
        }

        public async ValueTask<User> GetUserById(int id)
        {
            var result = await _context.Users.Include(x => x.Cards).Include(x => x.Buys).Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == id);
            if (result is not null)
            {
                return result;
            }
            return new User();
        }

        public async ValueTask<bool> UpdateUserAsync(int id, UsersDTO userDTO)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user is not null)
            {
                try
                {
                    user.FirstName = userDTO.FirstName;
                    user.LastName = userDTO.LastName;
                    user.PhoneNumber = userDTO.PhoneNumber;
                    user.Country = userDTO.Country;
                    user.UpdatedAt = DateTime.Now;

                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        public async ValueTask<User> GetUsersProducts(int id)
        {
            var user = await _context.Users.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == id);

            if (user is not null)
            {
                return user;
            }
            return new User();
        }
        public async ValueTask<User> GetUsersBuys(int id)
        {
            var user = await _context.Users.Include(x => x.Buys).FirstOrDefaultAsync(x => x.Id == id);

            if (user is not null)
            {
                return user;
            }
            return new User();
        }
        public async ValueTask<User> GetUsersCards(int id)
        {
            var user = await _context.Users.Include(x => x.Cards).FirstOrDefaultAsync(x => x.Id == id);

            if (user is not null)
            {
                return user;
            }
            return new User();
        }
    }
}
