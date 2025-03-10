namespace day2.DTOs
{
    public class OrderDTO
    {
        public int CustomerID { get; set; }
        public Dictionary<String, int> Products { get; set; }
    }
}
