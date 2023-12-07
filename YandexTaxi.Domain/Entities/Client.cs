namespace YandexTaxi.Domain.Entities
{
    public class Client : BaseClassForModels
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Bonus { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public ICollection<Card>? Cards { get; set; }
    }
}
