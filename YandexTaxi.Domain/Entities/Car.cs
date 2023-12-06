namespace YandexTaxi.Domain.Entities
{
    public class Car : BaseClassForModels
    {
        public string Model { get; set; }
        public string Number { get; set; }
        public string Color { get; set; }
        public int DriverId { get; set; }
        public Driver? Driver { get; set; }
    }
}
