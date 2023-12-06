using Microsoft.EntityFrameworkCore;
using OLX.Application.Interfaces;
using OLX.Domain.DTOs;
using OLX.Domain.Entities;
using OLX.Infastructure.DbContexts;

namespace OLX.Application.Services
{
    public class BuyService : IBuyService
    {
        private readonly OLXDbContext _context;

        public BuyService(OLXDbContext context)
        {
            _context = context;
        }

        public async ValueTask<bool> CreateBuyAsync(BuysDTO buyDTO)
        {
            try
            {
                var buy = new Buy()
                {
                    UserId = buyDTO.UserId,
                    SellId = buyDTO.SellId,
                    Amount = buyDTO.Amount,
                };
                var result = await _context.Sells.FirstOrDefaultAsync(x => x.Id == buy.SellId);
                if (result != null)
                {
                    _context.Sells.Remove(result);
                }
                await _context.Buys.AddAsync(buy);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async ValueTask<bool> DeleteBuyAsync(int id)
        {
            try
            {
                var result = await _context.Buys.FirstOrDefaultAsync(x => x.Id == id);

                _context.Buys.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async ValueTask<ICollection<Buy>> GetAllBuyAsync()
        {
            var result = await _context.Buys.ToListAsync();
            return result;
        }

        public async ValueTask<Buy> GetBuyById(int id)
        {
            var result = await _context.Buys.FirstOrDefaultAsync(x => x.Id == id);
            if (result is not null)
            {
                return result;
            }
            return new Buy();
        }

        public async ValueTask<bool> UpdateBuyAsync(int id, BuysDTO buyDTO)
        {
            try
            {
                var result = await _context.Buys.FirstOrDefaultAsync(x => x.Id == id);
                if (result is not null)
                {
                    result.UserId = id;
                    result.Amount = buyDTO.Amount;
                    result.SellId = buyDTO.SellId;
                    result.UpdatedAt = DateTime.Now;

                    _context.Buys.Update(result);
                    await _context.SaveChangesAsync();

                    return true;
                }
                return false;
            }
            catch { return false; }
        }
    }
}
