using SCMS.Domain.Common;

namespace SCMS.Domain.Entities
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public string CustomerName { get; set; }
        public List<OrderItem> Items { get; set; } = [];
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
        public decimal TotalAmount => Items.Sum(x => x.TotalPrice);

        public void AddItem(Guid productId, Guid orderId, string productName, decimal unitPrice, int quantity)
        {
            if(quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));

            var item = new OrderItem()
            {
                ProductId = productId,
                OrderId = orderId,
                ProductName = productName,
                UnitPrice = unitPrice,
                Quantity = quantity
            };

            Items.Add(item);
        }

        public void RemoveItem(Guid itemId)
        {
            var item = Items.FirstOrDefault(x => x.Id == itemId);
            if(item != null)
            {
                Items.Remove(item);
            }
        }
    }
}
