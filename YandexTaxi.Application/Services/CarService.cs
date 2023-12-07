using Microsoft.EntityFrameworkCore;
using YandexTaxi.Application.Interfaces;
using YandexTaxi.Domain.DTOs;
using YandexTaxi.Domain.Entities;
using YandexTaxi.Infastructure.DbContexts;

namespace YandexTaxi.Application.Services
{
    public class CarService : ICarService
    {
        private readonly YandexTaxiDbContext _context;

        public CarService(YandexTaxiDbContext context)
        {
            _context = context;
        }
        public async ValueTask<bool> CreateCarAsync(CarDTO carDTO)
        {
            try
            {
                var car = new Car()
                {
                    Model = carDTO.Model,
                    Number = carDTO.Number,
                    Color = carDTO.Color,
                    DriverId = carDTO.DriverId,
                };
                await _context.Cars.AddAsync(car);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async ValueTask<bool> DeleteCarAsync(int id)
        {
            try
            {
                var result = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);

                _context.Cars.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async ValueTask<ICollection<Car>> GetAllAsync()
        {
            var result = await _context.Cars.ToListAsync();
            return result;
        }

        public async ValueTask<Car> GetCarById(int id)
        {
            var result = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
            if (result is not null)
            {
                return result;
            }
            return new Car();
        }

        public async ValueTask<bool> UpdateCarAsync(int id, CarDTO carDTO)
        {
            try
            {
                var result = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
                if (result is not null)
                {
                    result.Model = carDTO.Model;
                    result.Number = carDTO.Number;
                    result.Color = carDTO.Color;
                    result.DriverId = carDTO.DriverId;
                    result.UpdatedAt = DateTime.Now;

                    _context.Cars.Update(result);
                    await _context.SaveChangesAsync();

                    return true;
                }
                return false;
            }
            catch { return false; }
        }
    }
}
