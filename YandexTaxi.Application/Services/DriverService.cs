using YandexTaxi.Application.Interfaces;
using YandexTaxi.Domain.DTOs;
using YandexTaxi.Domain.Entities;

namespace YandexTaxi.Application.Services
{
    public class DriverService : IDriverService
    {
        public ValueTask<bool> CreateDriverAsync(DriverDTO driverDTO)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> DeleteDriverAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ICollection<Driver>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<Driver> GetDriverById(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> UpdateDriverAsync(int id, DriverDTO driverDTO)
        {
            throw new NotImplementedException();
        }
    }
}
