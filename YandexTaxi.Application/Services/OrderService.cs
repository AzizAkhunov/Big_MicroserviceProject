using Microsoft.EntityFrameworkCore;
using YandexTaxi.Application.Interfaces;
using YandexTaxi.Domain.DTOs;
using YandexTaxi.Domain.Entities;
using YandexTaxi.Infastructure.DbContexts;

namespace YandexTaxi.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly YandexTaxiDbContext _context;

        public OrderService(YandexTaxiDbContext context)
        {
            _context = context;
        }

        public async ValueTask<bool> CreateOrderAsync(OrderDTO orderDTO)
        {
            try
            {
                var order = new Order()
                {
                    DriverId = orderDTO.DriverId,
                    ClientId = orderDTO.ClientId,
                    Status = orderDTO.Status,
                };
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async ValueTask<bool> DeleteOrderAsync(int id)
        {
            try
            {
                var result = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);

                _context.Orders.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async ValueTask<ICollection<Order>> GetAllAsync()
        {
            var result = await _context.Orders.ToListAsync();
            return result;
        }

        public async ValueTask<Order> GetOrderById(int id)
        {
            var result = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (result is not null)
            {
                return result;
            }
            return new Order();
        }

        public async ValueTask<bool> UpdateOrderAsync(int id, OrderDTO orderDTO)
        {
            try
            {
                var result = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
                if (result is not null)
                {
                    result.DriverId = orderDTO.DriverId;
                    result.ClientId = orderDTO.ClientId;
                    result.Status = orderDTO.Status;
                    result.UpdatedAt = DateTime.Now;

                    _context.Orders.Update(result);
                    await _context.SaveChangesAsync();

                    return true;
                }
                return false;
            }
            catch { return false; }
        }
    }
}
