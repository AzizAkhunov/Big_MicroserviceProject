using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAI.Domain.Entities
{
    public class Driver : BaseClassForModels
    {
        public int Id { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Stage { get; set; }
        public bool violation { get; set; }
        public string CarModel { get; set; }
        public string CarNumber { get; set; }
        public bool CarDocuments { get; set; }
    }
}
