using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMS.Application.Features.Products.Commands
{
    public record CreateProductCommand(string Name, string Description, decimal Price, int QuantityInStock) 
        : IRequest<Guid>;
}
