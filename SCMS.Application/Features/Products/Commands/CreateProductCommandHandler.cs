using MediatR;
using SCMS.Application.Interfaces.Repositories;
using SCMS.Domain.Entities;

namespace SCMS.Application.Features.Products.Commands
{
    public class CreateProductCommandHandler(IProductRepository productRepository)
        : IRequestHandler<CreateProductCommand, Guid>
    {
        public async Task<Guid> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product(command.Name, command.Description, command.Price, command.QuantityInStock);

            await productRepository.AddAsync(product);

            return product.Id;
        }
    }
}
