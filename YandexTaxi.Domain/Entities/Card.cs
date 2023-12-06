using System.ComponentModel.DataAnnotations.Schema;

namespace YandexTaxi.Domain.Entities
{
    [Table("Cards")]
    public class Card : BaseClassForModels
    {
        public int CardNumber { get; set; }
        public string Verify { get; set; }
        public decimal Amount { get; set; }
        public int ClientId { get; set; }
        public Client? Client { get; set; }
    }
}
