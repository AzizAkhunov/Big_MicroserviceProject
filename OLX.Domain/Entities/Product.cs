using System.ComponentModel.DataAnnotations.Schema;

namespace OLX.Domain.Entities
{
    [Table("Products")]
    public class Product : BaseClassForModels
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; } = true; //bu active yoki active masligini bislish uchun
        public Sell? Sell { get; set; }
    }
}
