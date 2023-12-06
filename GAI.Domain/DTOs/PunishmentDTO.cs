using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAI.Domain.DTOs
{
    public class PunishmentDTO
    {
        public int YPXId { get; set; }
        public int DriverId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
