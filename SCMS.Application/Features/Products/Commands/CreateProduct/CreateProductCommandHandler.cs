using MediatR;
using SCMS.Domain.Entities;
using SCMS.Domain.Interfaces;

namespace SCMS.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler(IProductRepository productRepository)
        : IRequestHandler<CreateProductCommand, Guid>
    {
        public async Task<Guid> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product(command.Name, command.Description, command.Price, command.StockQuantity);

            await productRepository.AddAsync(product);

            return product.Id;
        }
    }
}
