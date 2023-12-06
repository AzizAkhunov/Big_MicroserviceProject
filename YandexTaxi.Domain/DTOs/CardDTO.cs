using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTaxi.Domain.DTOs
{
    public class CardDTO
    {
        public int CardNumber { get; set; }
        public string Verify { get; set; }
        public decimal Amount { get; set; }
        public int ClientId { get; set; }
    }
}
