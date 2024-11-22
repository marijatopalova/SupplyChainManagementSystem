using MediatR;
using SCMS.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMS.Application.Features.Products.Queries
{
    public record GetProductByIdQuery(Guid Id) : IRequest<ProductDto>;
}
