using YandexTaxi.Domain.DTOs;
using YandexTaxi.Domain.Entities;

namespace YandexTaxi.Application.Interfaces
{
    public interface IOrderService
    {
        ValueTask<ICollection<Order>> GetAllAsync();
        ValueTask<bool> CreateOrderAsync(OrderDTO orderDTO);
        ValueTask<bool> DeleteOrderAsync(int id);
        ValueTask<bool> UpdateOrderAsync(int id, OrderDTO orderDTO);
        ValueTask<Card> GetOrderById(int id);
    }
}
