﻿namespace day4.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public virtual List<OrderProduct> orderProduct { get; set; } = new List<OrderProduct>();
    }
}
