namespace SCMS.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime OrderDate { get; private set; } = DateTime.UtcNow;
        public string CustomerName { get; private set; }
        public List<OrderItem> Items { get; private set; } = [];
        public decimal TotalAmount => Items.Sum(x => x.TotalPrice);

        public Order(string customerName)
        {
            CustomerName = customerName;
        }

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
