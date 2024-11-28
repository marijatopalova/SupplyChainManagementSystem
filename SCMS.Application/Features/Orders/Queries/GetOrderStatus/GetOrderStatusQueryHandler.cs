using MediatR;
using SCMS.Application.Dtos;
using SCMS.Domain.Interfaces;

namespace SCMS.Application.Features.Orders.Queries.GetOrderStatus
{
    internal class GetOrderStatusQueryHandler(IOrderRepository orderRepository) 
        : IRequestHandler<GetOrderStatusQuery, OrderStatusDto>
    {
        public async Task<OrderStatusDto> Handle(GetOrderStatusQuery request, CancellationToken cancellationToken)
        {
            var order = await orderRepository.GetByIdAsync(request.Id);

            if (order == null)
                throw new KeyNotFoundException("Order not found.");

            return new OrderStatusDto
            {
                OrderId = order.Id,
                CurrentStatus = order.OrderStatus.ToString(),
                TrackingNumber = order.TrackingNumber,
                ShippingCarrier = order.ShippingCarrier,
            };
        }
    }
}
