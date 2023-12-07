using System.ComponentModel.DataAnnotations.Schema;


namespace YandexTaxi.Domain.Entities
{
    [Table("Drivers")]
    public class Driver : BaseClassForModels
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Amount { get; set; } = 1000000;
        public Car? Car { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public ICollection<Scrin>? Scrins { get; set; }
    }
}
