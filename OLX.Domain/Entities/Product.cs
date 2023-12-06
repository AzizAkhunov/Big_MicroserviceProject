using System.ComponentModel.DataAnnotations.Schema;

namespace OLX.Domain.Entities
{
    [Table("Products")]
    public class Product : BaseClassForModels
    {
        public string Name { get; set; }

    }
}
