namespace day4.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderProductDTO> OrderProducts { get; set; } = new List<OrderProductDTO>();
        public CustomerDTO Customer { get; set; }
    }
}
