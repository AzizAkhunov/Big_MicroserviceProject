using System.ComponentModel.DataAnnotations.Schema;

namespace OLX.Domain.Entities
{
    [Table("Cards")]
    public class Card : BaseClassForModels
    {
        public long CardNumber { get; set; }
        public string Verify { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
