using System.ComponentModel.DataAnnotations.Schema;

namespace YandexTaxi.Domain.Entities
{
    [Table("Scrins")]
    public class Scrin : BaseClassForModels
    {
        public string DriverName { get; set; }
        public int CarId { get; set; }
        public Car? Car { get; set; }
        public int Longtitude { get; set; }
        public decimal Price { get; set; }
        public decimal Bonus { get; set; }
        public bool Status { get; set; } = true; //active active emasligini aniqlash uchun 
    }
}
