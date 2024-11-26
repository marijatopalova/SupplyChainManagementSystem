using SCMS.Domain.Common;

namespace SCMS.Domain.Entities
{
    public class Product(string name, string description, decimal price, int stockQuantity) : BaseEntity
    {
        public string Name { get; set; } = name;
        public string Description { get; set; } = description;
        public decimal Price { get; set; } = price;
        public int StockQuantity { get; set; } = stockQuantity;
        public bool IsDeleted { get; set; }

        public void UpdateDetails(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public void AdjustStock(int quantity)
        {
            StockQuantity += quantity;
            if (StockQuantity < 0)
            {
                throw new InvalidOperationException("Stock quantity cannot be negative.");
            }
        }
    }
}
