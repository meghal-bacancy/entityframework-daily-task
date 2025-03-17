namespace day4.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public int CustomerId { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual List<OrderProduct> orderProduct { get; set; } = new List<OrderProduct>();
    }
}
