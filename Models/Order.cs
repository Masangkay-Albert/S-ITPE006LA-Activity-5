using System;
using System.Collections.Generic;

namespace S_ITPE006LA___Activity_5.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerEmail { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public decimal TotalAmount { get; set; }

        // Navigation property
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
