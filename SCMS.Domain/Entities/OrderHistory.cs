using SCMS.Domain.Common;

namespace SCMS.Domain.Entities
{
    public class OrderHistory : BaseEntity
    {
        public Guid OrderId { get; set; }
        public OrderStatus PreviousStatus { get; set; }
        public OrderStatus NewStatus { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Order Order { get; set; }
    }
}
