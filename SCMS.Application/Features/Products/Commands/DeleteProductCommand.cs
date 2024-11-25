using MediatR;

namespace SCMS.Application.Features.Products.Commands
{
    public record DeleteProductCommand(Guid Id) : IRequest;
}
