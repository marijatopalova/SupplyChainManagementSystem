using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCMS.Application.Features.Products.Commands;

namespace SCMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IMediator mediator) : ControllerBase
    {
        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="command">The create product command.</param>
        /// <returns>The ID of the newly created product.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            if (command == null)
                return BadRequest("Command cannot be null");

            var result = await mediator.Send(command);

            return Ok(result);
        }
    }
}
