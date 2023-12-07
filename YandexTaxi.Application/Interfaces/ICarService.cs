using YandexTaxi.Domain.DTOs;
using YandexTaxi.Domain.Entities;

namespace YandexTaxi.Application.Interfaces
{
    public interface ICarService
    {
        ValueTask<ICollection<Car>> GetAllAsync();
        ValueTask<bool> CreateCarAsync(CarDTO carDTO);
        ValueTask<bool> DeleteCarAsync(int id);
        ValueTask<bool> UpdateCarAsync(int id, CarDTO carDTO);
        ValueTask<Car> GetCarById(int id);
    }
}
