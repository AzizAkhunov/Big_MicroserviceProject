namespace OLX.Domain.DTOs
{
    public class SellsDTO
    {
        public int ProductId { get; set; }
        public decimal GeneralPrice { get; set; }
        public bool Status { get; set; } = false;
    }
}
