using MediatR;
using SCMS.Application.Dtos;

namespace SCMS.Application.Features.Products.Commands.UpdateProduct
{
    public record UpdateProductCommand(Guid Id, string Name, string Description, decimal Price, int StockQuantity) : IRequest<ProductDto>;
}
