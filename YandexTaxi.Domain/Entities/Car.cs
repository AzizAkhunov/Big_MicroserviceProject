using System.ComponentModel.DataAnnotations.Schema;

namespace YandexTaxi.Domain.Entities
{
    [Table("Cars")]
    public class Car : BaseClassForModels
    {
        public string Model { get; set; }
        public string Number { get; set; }
        public string Color { get; set; }
        public int DriverId { get; set; }
        public Driver? Driver { get; set; }
        public ICollection<Scrin>? Scrins { get; set; }
    }
}
