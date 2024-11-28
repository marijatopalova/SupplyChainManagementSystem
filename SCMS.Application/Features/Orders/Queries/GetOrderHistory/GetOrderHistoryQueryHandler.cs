using MediatR;
using SCMS.Application.Dtos;
using SCMS.Domain.Interfaces;

namespace SCMS.Application.Features.Orders.Queries.GetOrderHistory
{
    public class GetOrderHistoryQueryHandler(IOrderRepository orderRepository)
        : IRequestHandler<GetOrderHistoryQuery, List<OrderHistoryDto>>
    {
        public async Task<List<OrderHistoryDto>> Handle(GetOrderHistoryQuery request, CancellationToken cancellationToken)
        {
            var order = await orderRepository.GetByIdAsync(request.Id);

            if (order == null)
                throw new KeyNotFoundException("Order not found.");

            return order.OrderHistory.Select(x => new OrderHistoryDto
            {
                PreviousStatus = x.PreviousStatus,
                NewStatus = x.NewStatus,
                UpdatedAt = x.UpdatedAt,
            }).ToList();
        }
    }
}
