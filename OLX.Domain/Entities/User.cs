using System.ComponentModel.DataAnnotations.Schema;

namespace OLX.Domain.Entities
{
    [Table("Users")]
    public class User : BaseClassForModels
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public ICollection<Buy> Buys { get; set; }
        public ICollection<Card> Cards { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
