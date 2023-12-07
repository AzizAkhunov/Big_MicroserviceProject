using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using YandexTaxi.Application.Interfaces;
using YandexTaxi.Domain.DTOs;
using YandexTaxi.Domain.Entities;
using YandexTaxi.Infastructure.DbContexts;

namespace YandexTaxi.Application.Services
{
    public class ScrinService : IScrinService
    {
        private readonly YandexTaxiDbContext _context;

        public ScrinService(YandexTaxiDbContext context)
        {
            _context = context;
        }


        public async ValueTask<decimal> GiveToll(int scrinId) //Kira haqqi
        {
            var result = await _context.Scrins.FirstOrDefaultAsync(x => x.Id == scrinId);
            if (result is not null)
            {
                if (result.Longtitude > 3)
                {
                    result.Price = result.Longtitude * 1200;
                }
                else if (result.Longtitude <= 3)
                {
                    result.Price = 5000;
                }
                await _context.SaveChangesAsync();
                return result.Price;
            }
            return 0;
        }


        public async ValueTask<bool> CreateScrinAsync(ScrinDTO scrinDTO)
        {
            try
            {
                decimal a;
                var scrin = new Scrin()
                {
                    DriverId = scrinDTO.DriverId,
                    Longtitude = scrinDTO.Longtitude,
                };
                


                await _context.Scrins.AddAsync(scrin);
                await _context.SaveChangesAsync();
                scrin.Price = await GiveToll(scrin.Id);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async ValueTask<string> DeleteScrinAsync(int id)
        {
            try
            {
                var result = await _context.Scrins.FirstOrDefaultAsync(x => x.Id == id);
                decimal narx = await GiveToll(result.Id);
                _context.Scrins.Remove(result);
                await _context.SaveChangesAsync();
                return $"{narx} - sum Bizning Companiyadan foydalanganiz uchun rahmat";
            }
            catch
            {
                return "Error!";
            }
        }

        public async ValueTask<ICollection<Scrin>> GetAllAsync()
        {
            var result = await _context.Scrins.ToListAsync();
            return result;
        }

        public async ValueTask<Scrin> GetScrinById(int id)
        {
            var result = await _context.Scrins.FirstOrDefaultAsync(x => x.Id == id);
            if (result is not null)
            {
                return result;
            }
            return new Scrin();
        }

    }
}
