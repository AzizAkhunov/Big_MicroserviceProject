using System.ComponentModel.DataAnnotations.Schema;

namespace OLX.Domain.Entities
{
    [Table("Sells")]
    public class Sell : BaseClassForModels
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public decimal GeneralPrice { get; set; }
        public bool Status { get; set; } = false; //sotilgan sotilmaganligini aniqlash uchun
    }
}
