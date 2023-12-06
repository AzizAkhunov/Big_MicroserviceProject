namespace OLX.Domain.DTOs
{
    public class CardsDTO
    {
        public long CardNumber { get; set; }
        public string Verify { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }
    }
}
