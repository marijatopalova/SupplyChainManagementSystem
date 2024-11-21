namespace SCMS.Domain.Entities
{
    public class Inventory
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }

        public Inventory(Guid productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public void AdjustQuantity(int amount)
        {
            Quantity += amount;
            if (Quantity < 0)
                throw new InvalidOperationException("Inventory quantity cannot be negative.");
        }
    }
}
