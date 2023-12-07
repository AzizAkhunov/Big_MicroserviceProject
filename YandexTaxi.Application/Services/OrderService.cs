using YandexTaxi.Application.Interfaces;
using YandexTaxi.Domain.DTOs;
using YandexTaxi.Domain.Entities;

namespace YandexTaxi.Application.Services
{
    public class OrderService : IOrderService
    {
        public ValueTask<bool> CreateOrderAsync(OrderDTO orderDTO)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> DeleteOrderAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ICollection<Order>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<Card> GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> UpdateOrderAsync(int id, OrderDTO orderDTO)
        {
            throw new NotImplementedException();
        }
    }
}
