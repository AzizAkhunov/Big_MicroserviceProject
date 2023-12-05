using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAI.Domain.Entities
{
    public class YPX : BaseClassForModels
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Passport { get; set; }
        public string Description { get; set; }
        public bool YPXDocument { get; set; }
    }
}
