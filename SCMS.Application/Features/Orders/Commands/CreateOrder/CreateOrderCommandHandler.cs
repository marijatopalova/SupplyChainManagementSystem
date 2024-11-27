using MediatR;
using SCMS.Domain.Entities;
using SCMS.Domain.Interfaces;

namespace SCMS.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler(IOrderRepository orderRepository)
        : IRequestHandler<CreateOrderCommand, Guid>
    {
        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order()
            {
                CustomerName = request.CustomerName,
                Items = request.Items.Select(item => new OrderItem()
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                }).ToList()
            };

            await orderRepository.AddAsync(order);

            return order.Id;
        }
    }
}
