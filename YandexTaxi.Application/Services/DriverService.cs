using Microsoft.EntityFrameworkCore;
using YandexTaxi.Application.Interfaces;
using YandexTaxi.Domain.DTOs;
using YandexTaxi.Domain.Entities;
using YandexTaxi.Infastructure.DbContexts;

namespace YandexTaxi.Application.Services
{
    public class DriverService : IDriverService
    {
        private readonly YandexTaxiDbContext _context;

        public DriverService(YandexTaxiDbContext context)
        {
            _context = context;
        }

        public async ValueTask<bool> CreateDriverAsync(DriverDTO driverDTO)
        {
            try
            {
                var driver = new Driver()
                {
                    FirstName = driverDTO.FirstName,
                    LastName = driverDTO.LastName,
                    PhoneNumber = driverDTO.PhoneNumber,
                };
                await _context.Drivers.AddAsync(driver);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async ValueTask<bool> DeleteDriverAsync(int id)
        {
            try
            {
                var result = await _context.Drivers.FirstOrDefaultAsync(x => x.Id == id);

                _context.Drivers.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async ValueTask<ICollection<Driver>> GetAllAsync()
        {
            var result = await _context.Drivers.Include(x => x.Orders).ToListAsync();
            return result;
        }

        public async ValueTask<Driver> GetDriverById(int id)
        {
            var result = await _context.Drivers.Include(x => x.Orders).FirstOrDefaultAsync(x => x.Id == id);
            if (result is not null)
            {
                return result;
            }
            return new Driver();
        }

        public async ValueTask<bool> UpdateDriverAsync(int id, DriverDTO driverDTO)
        {
            try
            {
                var result = await _context.Drivers.FirstOrDefaultAsync(x => x.Id == id);
                if (result is not null)
                {
                    result.FirstName = driverDTO.FirstName;
                    result.LastName = driverDTO.LastName;
                    result.PhoneNumber = driverDTO.PhoneNumber;
                    result.UpdatedAt = DateTime.Now;

                    _context.Drivers.Update(result);
                    await _context.SaveChangesAsync();

                    return true;
                }
                return false;
            }
            catch { return false; }
        }
        public async ValueTask<bool> AskForIncrease(int driverId, decimal approximate_amount)
        {
            var driver = await _context.Drivers.FirstOrDefaultAsync(x => x.Id == driverId);
            int count = driver.Orders.Count();
            if (driver is not null)
            {
                if (count > 5)
                {
                    if (approximate_amount < 1500000)
                    {
                        driver.Amount = approximate_amount;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (count > 15)
                {
                    if (approximate_amount < 3500000)
                    {
                        driver.Amount = approximate_amount;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
