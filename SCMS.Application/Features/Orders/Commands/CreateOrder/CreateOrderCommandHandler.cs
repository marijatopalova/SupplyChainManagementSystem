using MediatR;
using SCMS.Domain.Entities;
using SCMS.Domain.Interfaces;

namespace SCMS.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler(IOrderRepository orderRepository, IProductRepository productRepository)
        : IRequestHandler<CreateOrderCommand, Guid>
    {
        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            foreach(var item in request.Items)
            {
                var product = await productRepository.GetByIdAsync(item.ProductId) 
                    ?? throw new Exception("Product was not found");
            }

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
