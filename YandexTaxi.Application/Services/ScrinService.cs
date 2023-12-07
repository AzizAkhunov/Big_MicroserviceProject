using Microsoft.EntityFrameworkCore;
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

        public async ValueTask<bool> CreateScrinAsync(int clientId,ScrinDTO scrinDTO)
        {
            try
            {
                var scrin = new Scrin()
                {
                    DriverName = scrinDTO.DriverName,
                    Price = scrinDTO.Price,
                    CarId = scrinDTO.CarId,
                    Longtitude = scrinDTO.Longtitude,
                    OrderId = scrinDTO.OrderId,
                };
                if (scrin.Longtitude > 3)
                {
                    var client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == clientId);
                    if (client is not null)
                    {
                        client.Bonus += 200;
                    }
                }
                await _context.Scrins.AddAsync(scrin);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async ValueTask<bool> DeleteScrinAsync(int id)
        {
            try
            {
                var result = await _context.Scrins.FirstOrDefaultAsync(x => x.Id == id);

                _context.Scrins.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
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

        public async ValueTask<bool> PayWithBonus(int scrinId,int clientId)
        {
            var result = await _context.Scrins.FirstOrDefaultAsync(x => x.Id == scrinId);
            var client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == clientId);
            if (result is not null && client is not null)
            {
                if (client.Bonus >= await GiveToll(scrinId))
                {
                    client.Bonus -= await GiveToll(scrinId);

                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }

        public async ValueTask<bool> UpdateScrinAsync(int id, ScrinDTO scrinDTO)
        {
            try
            {
                var result = await _context.Scrins.FirstOrDefaultAsync(x => x.Id == id);
                if (result is not null)
                {
                    result.DriverName = scrinDTO.DriverName;
                    result.Price = scrinDTO.Price;
                    result.CarId = scrinDTO.CarId;
                    result.Longtitude = scrinDTO.Longtitude;
                    result.OrderId = scrinDTO.OrderId;
                    result.UpdatedAt = DateTime.Now;

                    _context.Scrins.Update(result);
                    await _context.SaveChangesAsync();

                    return true;
                }
                return false;
            }
            catch { return false; }
        }
    }
}
