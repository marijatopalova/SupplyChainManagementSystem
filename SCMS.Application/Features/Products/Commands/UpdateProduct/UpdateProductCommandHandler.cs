using AutoMapper;
using MediatR;
using SCMS.Application.Dtos;
using SCMS.Domain.Interfaces;

namespace SCMS.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper) 
        : IRequestHandler<UpdateProductCommand, ProductDto>
    {
        public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new Exception("The product was not found.");
            }

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.StockQuantity = request.StockQuantity;

            await productRepository.UpdateAsync(product);

            return mapper.Map<ProductDto>(product);
        }
    }
}
