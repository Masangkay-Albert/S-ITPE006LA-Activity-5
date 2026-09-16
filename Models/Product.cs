namespace S_ITPE006LA___Activity_5.Models
{
    public class Product
    {
        public int Id { get; set; }                       // Primary key
        public string Name { get; set; } = null!;         // Required
        public string? Description { get; set; }
        public decimal Price { get; set; }

        // Foreign keys
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }

        // Navigation properties
        public Category? Category { get; set; }
        public Supplier? Supplier { get; set; }
    }
}   