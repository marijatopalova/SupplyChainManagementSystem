using AutoMapper;
using MediatR;
using SCMS.Application.Dtos;
using SCMS.Domain.Interfaces;

namespace SCMS.Application.Features.Products.Queries
{
    public class GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.Id);

            var productDto = mapper.Map<ProductDto>(product);

            return productDto;
        }
    }
}
