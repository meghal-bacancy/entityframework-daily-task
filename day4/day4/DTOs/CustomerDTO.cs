namespace day4.DTOs
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsVIP { get; set; }
        public List<OrderDTO> Orders { get; set; } = new List<OrderDTO>();
    }

}
