using MediatR;
using SCMS.Application.Dtos;

namespace SCMS.Application.Features.Orders.Commands.CreateOrder
{
    public record CreateOrderCommand(string CustomerName, List<OrderItemDto> Items) : IRequest<Guid>;
}
