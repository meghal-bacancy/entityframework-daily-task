namespace day4.DTOs
{
    public class OrderProductDTO
    {
        public int OrderProductId { get; set; }
        public int Quantity { get; set; }
        public ProductDTO Product { get; set; }
    }
}
