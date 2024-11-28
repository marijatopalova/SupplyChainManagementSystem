using MediatR;
using SCMS.Application.Dtos;

namespace SCMS.Application.Features.Orders.Queries.GetOrderStatus
{
    public record GetOrderStatusQuery(Guid Id) : IRequest<OrderStatusDto>;
}
