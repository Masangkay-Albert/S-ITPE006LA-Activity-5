using System.Collections.Generic;

namespace S_ITPE006LA___Activity_5.Models
{
    public class Supplier
    {
        public int Id { get; set; }                      // Primary key
        public string Name { get; set; } = null!;        // Required
        public string? ContactEmail { get; set; }

        // One-to-many: Supplier -> Products
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}