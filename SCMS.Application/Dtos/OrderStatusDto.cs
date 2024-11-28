using SCMS.Domain.Common;

namespace SCMS.Application.Dtos
{
    public class OrderStatusDto
    {
        public Guid OrderId { get; set; }
        public string CurrentStatus { get; set; }
        public string? TrackingNumber { get; set; }
        public string? ShippingCarrier { get; set; }
    }
}
