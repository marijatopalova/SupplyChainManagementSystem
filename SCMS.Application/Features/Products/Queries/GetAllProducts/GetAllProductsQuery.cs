using MediatR;
using SCMS.Application.Dtos;

namespace SCMS.Application.Features.Products.Queries.GetAllProducts
{
    public record GetAllProductsQuery() : IRequest<List<ProductDto>>;
}
