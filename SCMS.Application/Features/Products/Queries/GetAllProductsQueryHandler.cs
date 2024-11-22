using AutoMapper;
using MediatR;
using SCMS.Application.Dtos;
using SCMS.Domain.Interfaces;

namespace SCMS.Application.Features.Products.Queries
{
    public class GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper) 
        : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
    {
        public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetAllAsync();

            var productDtoList = mapper.Map<List<ProductDto>>(products);

            return productDtoList;
        }
    }
}
