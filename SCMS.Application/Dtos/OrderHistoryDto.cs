using SCMS.Domain.Common;

namespace SCMS.Application.Dtos
{
    public class OrderHistoryDto
    {
        public DateTime UpdatedAt { get; set; }
        public OrderStatus PreviousStatus { get; set; }
        public OrderStatus NewStatus { get; set; }
    }
}
