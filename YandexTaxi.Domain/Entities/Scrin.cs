using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YandexTaxi.Domain.Entities
{
    [Table("Scrins")]
    public class Scrin
    {
        public int Id { get; set; }
        public int DriverId { get; set; }
        public Driver? Driver { get; set; }
        public int Longtitude { get; set; }
        public decimal Price { get; set; }
    }
}
