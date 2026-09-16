using System.Collections.Generic;

namespace S_ITPE006LA___Activity_5.Models
{
    public class Category
    {
        public int Id { get; set; }                      // Primary key
        public string Name { get; set; } = null!;        // Required

        // One-to-many: Category -> Products
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}