using System.Text.Json.Serialization;

namespace day4.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsVIP { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public virtual List<Order> Orders { get; set; } = new List<Order>();
    }
}
