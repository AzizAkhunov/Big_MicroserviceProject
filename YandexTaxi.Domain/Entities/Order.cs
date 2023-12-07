using System.ComponentModel.DataAnnotations.Schema;
using YandexTaxi.Domain.Enums;

namespace YandexTaxi.Domain.Entities
{
    [Table("Orders")]
    public class Order : BaseClassForModels
    {
        public int DriverId { get; set; }
        public Driver? Driver { get; set; }
        public int ClientId { get; set; }
        public Client? Client { get; set; }
        public string? Description { get; set; }
        public OrderStatusEnum Status { get; set; } = OrderStatusEnum.Econom;
    }
}
