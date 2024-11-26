using SCMS.Domain.Common;

namespace SCMS.Domain.Entities
{
    public class Order(string customerName) : BaseEntity
    {
        public DateTime OrderDate { get; private set; } = DateTime.UtcNow;
        public string CustomerName { get; private set; } = customerName;
        public List<OrderItem> Items { get; private set; } = [];
        public decimal TotalAmount => Items.Sum(x => x.TotalPrice);

        public void AddItem(Guid productId, string productName, decimal unitPrice, int quantity)
        {
            if(quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));

            var item = new OrderItem(productId, productName, unitPrice, quantity);
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
