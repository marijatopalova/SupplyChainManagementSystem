using MediatR;
using SCMS.Domain.Interfaces;

namespace SCMS.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler(IProductRepository productRepository)
        : IRequestHandler<DeleteProductCommand>
    {
        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.Id);
            if (product == null)
            {
                throw new Exception("The product was not found.");
            }

            if (product.IsDeleted)
            {
                throw new Exception("The product is already deleted.");
            }

            await productRepository.DeleteAsync(product);
        }
    }
}
