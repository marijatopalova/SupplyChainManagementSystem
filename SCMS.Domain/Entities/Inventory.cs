using SCMS.Domain.Common;

namespace SCMS.Domain.Entities
{
    public class Inventory(Guid productId, int quantity) : BaseEntity
    {
        public Guid ProductId { get; private set; } = productId;
        public int Quantity { get; private set; } = quantity;

        public void AdjustQuantity(int amount)
        {
            Quantity += amount;
            if (Quantity < 0)
                throw new InvalidOperationException("Inventory quantity cannot be negative.");
        }
    }
}
