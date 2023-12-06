using System.ComponentModel.DataAnnotations.Schema;

namespace GAI.Domain.Entities
{
    [Table("Punishments")]
    public class Punishment : BaseClassForModels
    {
        public int YPXId { get; set; }
        public YPX? YPX { get; set; }

        public int DriverId { get; set; }
        public Driver? Driver { get; set; }

        public decimal Price { get; set; }
        public string Description { get; set; }
        
    }
}
