using YandexTaxi.Domain.Enums;

namespace YandexTaxi.Domain.DTOs
{
    public class OrderDTO
    {
        public int DriverId { get; set; }
        public int ClientId { get; set; }
        public OrderStatusEnum Status { get; set; } = OrderStatusEnum.Econom;
    }
}
