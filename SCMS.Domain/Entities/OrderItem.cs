
using SCMS.Domain.Common;

namespace SCMS.Domain.Entities
{
    public class OrderItem(Guid productId, string productName, decimal unitPrice, int quantity) : BaseEntity
    {
        public Guid ProductId { get; private set; } = productId;
        public string ProductName { get; private set; } = productName;
        public decimal UnitPrice { get; private set; } = unitPrice;
        public int Quantity { get; private set; } = quantity;
        public decimal TotalPrice => UnitPrice * Quantity;

        public void UpdateQuantity(int newQuantity)
        {
            if (newQuantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.", nameof(newQuantity));

            Quantity = newQuantity;
        }
    }
}