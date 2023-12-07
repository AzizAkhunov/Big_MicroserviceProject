using YandexTaxi.Application.Interfaces;
using YandexTaxi.Domain.DTOs;
using YandexTaxi.Domain.Entities;

namespace YandexTaxi.Application.Services
{
    public class CarService : ICarService
    {
        public ValueTask<bool> CreateCarAsync(CarDTO carDTO)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> DeleteCarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ICollection<Car>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<Driver> GetCarById(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> UpdateCarAsync(int id, CarDTO carDTO)
        {
            throw new NotImplementedException();
        }
    }
}
