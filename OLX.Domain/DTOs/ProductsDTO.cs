namespace OLX.Domain.DTOs
{
    public class ProductsDTO
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int UserId { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; } = false;
    }
}
