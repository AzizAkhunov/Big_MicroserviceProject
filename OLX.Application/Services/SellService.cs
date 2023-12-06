using Microsoft.EntityFrameworkCore;
using OLX.Application.Interfaces;
using OLX.Domain.DTOs;
using OLX.Domain.Entities;
using OLX.Infastructure.DbContexts;

namespace OLX.Application.Services
{
    public class SellService : ISellService
    {
        private readonly OLXDbContext _context;

        public SellService(OLXDbContext context)
        {
            _context = context;
        }
        public async ValueTask<bool> CreateSellAsync(SellsDTO sellDTO)
        {
            try // Logika nmada ? Bunda Biz sellga product quyganda u product databasedan uchadi u sellda turadi va ushatta buy qilish mumkin buladi
            {
                var sell = new Sell()
                {
                    ProductId = sellDTO.ProductId,
                    GeneralPrice = sellDTO.GeneralPrice,
                    Status = true
                };
                var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == sell.ProductId);
                if (product != null)
                {
                    product.Status = false;
                    _context.Products.Update(product);
                }
                await _context.Sells.AddAsync(sell);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async ValueTask<bool> DeleteSellAsync(int id)
        {
            try
            {
                var result = await _context.Sells.FirstOrDefaultAsync(x => x.Id == id);

                _context.Sells.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async ValueTask<ICollection<Sell>> GetAllSellAsync()
        {
            var result = await _context.Sells.ToListAsync();
            return result;
        }

        public async ValueTask<Sell> GetSellById(int id)
        {
            var result = await _context.Sells.FirstOrDefaultAsync(x => x.Id == id);
            if (result is not null)
            {
                return result;
            }
            return new Sell();
        }

        public async ValueTask<bool> UpdateSellAsync(int id, SellsDTO sellDTO)
        {
            try
            {
                var result = await _context.Sells.FirstOrDefaultAsync(x => x.Id == id);
                if (result is not null)
                {
                    result.ProductId = sellDTO.ProductId;
                    result.GeneralPrice = sellDTO.GeneralPrice;
                    result.UpdatedAt = DateTime.Now;

                    _context.Sells.Update(result);
                    await _context.SaveChangesAsync();

                    return true;
                }
                return false;
            }
            catch { return false; }
        }
    }
}
