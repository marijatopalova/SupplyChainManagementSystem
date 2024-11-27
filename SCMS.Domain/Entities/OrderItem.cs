
using SCMS.Domain.Common;

namespace SCMS.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => UnitPrice * Quantity;

        public Product Product { get; set; }
        public Order Order { get; set; }

        public void UpdateQuantity(int newQuantity)
        {
            if (newQuantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.", nameof(newQuantity));

            Quantity = newQuantity;
        }
    }
}