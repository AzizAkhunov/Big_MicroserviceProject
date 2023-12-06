using GAI.Application.Interfaces;
using GAI.Domain.DTOs;
using GAI.Domain.Entities;
using GAI.Infastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace GAI.Application.Services
{
    public class DriverService : IDriverService
    {
        private readonly GAIDbContext _dbContext;

        public DriverService(GAIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async ValueTask<bool> CreateDriverAsync(DriverDTO driverDTO)
        {
            try
            {
                var driver = new Driver()
                {
                    FirstName = driverDTO.FirstName,
                    LastName = driverDTO.LastName,
                    Age = driverDTO.Age,
                    Stage = driverDTO.Stage,
                    Violation = driverDTO.Violation,
                    CarModel = driverDTO.CarModel,
                    CarNumber = driverDTO.CarNumber,
                    CarColor = driverDTO.CarColor,
                    CarDocuments = driverDTO.CarDocuments,
                };
                await _dbContext.Drivers.AddAsync(driver);
                await _dbContext.SaveChangesAsync();
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
                var result = await _dbContext.Drivers.FirstOrDefaultAsync(x => x.Id == id);

                _dbContext.Drivers.Remove(result);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async ValueTask<ICollection<Driver>> GetAllAsync()
        {
            var result = await _dbContext.Drivers.ToListAsync();
            return result;
        }

        public async ValueTask<Driver> GetDriverById(int id)
        {
            var result = await _dbContext.Drivers.FirstOrDefaultAsync(x => x.Id == id);
            if (result is not null)
            {
                return result;
            }
            return new Driver();
        }

        public async ValueTask<bool> UpdateDriverAsync(int id ,DriverDTO driverDTO)
        {
            try
            {
                var driver = await _dbContext.Drivers.FirstOrDefaultAsync(x => x.Id == id);
                if (driver is not null)
                {
                    driver.FirstName = driverDTO.FirstName;
                    driver.LastName = driverDTO.LastName;
                    driver.Age = driverDTO.Age;
                    driver.Stage = driverDTO.Stage;
                    driver.Violation = driverDTO.Violation;
                    driver.CarModel = driverDTO.CarModel;
                    driver.CarNumber = driverDTO.CarNumber;
                    driver.CarColor = driverDTO.CarColor;
                    driver.CarDocuments = driverDTO.CarDocuments;
                    driver.UpdatedAt = DateTime.Now;

                    _dbContext.Drivers.Update(driver);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public string GetDriverPunishments(int driverId)
        {
            var driversPunishments = _dbContext.Drivers
                .Include(x => x.Punishments).FirstOrDefault(x => x.Id == driverId);

            if (driversPunishments != null)
            {
                Console.WriteLine($"Driver ID: {driversPunishments.Id}, Name: {driversPunishments.FirstName}");

                foreach (var punishment in driversPunishments.Punishments)
                {
                    return $"  Punishment ID: {punishment.Id}, Description: {punishment.Description}";
                }
            }
            else
            {
                return $"Driver with ID {driverId} not found.";
            }
            return "";
        }
    }
}
