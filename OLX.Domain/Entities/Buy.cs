using System.ComponentModel.DataAnnotations.Schema;

namespace OLX.Domain.Entities
{
    [Table("Buys")]
    public class Buy : BaseClassForModels
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public decimal Amount { get; set; }
    }
}
