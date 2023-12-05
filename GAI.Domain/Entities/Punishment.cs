using System.ComponentModel.DataAnnotations.Schema;

namespace GAI.Domain.Entities
{
    public class Punishment : BaseClassForModels
    {
        public int YPX_Id { get; set; }
        public int DriverId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        
        [ForeignKey("YPX_Id")]
        public YPX YPX { get; set; }
        
        [ForeignKey("DriverId")]
        public Driver Driver { get; set; }
    }
}
