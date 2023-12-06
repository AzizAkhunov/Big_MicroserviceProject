using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLX.Domain.DTOs
{
    public class BuysDTO
    {
        public int UserId { get; set; }
        public int SellId { get; set; }
        public decimal Amount { get; set; }
    }
}
