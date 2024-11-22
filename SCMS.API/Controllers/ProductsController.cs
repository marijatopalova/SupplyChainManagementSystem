using MediatR;
using Microsoft.AspNetCore.Mvc;
using SCMS.Application.Dtos;
using SCMS.Application.Features.Products.Commands;
using SCMS.Application.Features.Products.Queries;

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

        /// <summary>
        /// Retrieves a list of all products from the database.
        /// </summary>
        /// <returns>A list of products that are not marked as deleted.</returns>
        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAllProducts()
        {
            var query = new GetAllProductsQuery();

            var products = await mediator.Send(query);

            return Ok(products);
        }
    }
}
