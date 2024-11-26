using MediatR;
using SCMS.Application.Dtos;

namespace SCMS.Application.Features.Products.Queries.GetProductById
{
    public record GetProductByIdQuery(Guid Id) : IRequest<ProductDto>;
}
