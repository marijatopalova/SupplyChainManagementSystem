using MediatR;
using SCMS.Application.Dtos;

namespace SCMS.Application.Features.Orders.Queries.GetOrderHistory
{
    public record GetOrderHistoryQuery(Guid Id) : IRequest<List<OrderHistoryDto>>;
}
