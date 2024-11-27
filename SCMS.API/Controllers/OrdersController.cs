using MediatR;
using Microsoft.AspNetCore.Mvc;
using SCMS.Application.Features.Orders.Commands.CreateOrder;

namespace SCMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(IMediator mediator) : ControllerBase
    {
        /// <summary>
        /// Creates a new order.
        /// </summary>
        /// <param name="command">The create order command.</param>
        /// <returns>The ID of the newly created order.</returns>
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateOrder([FromBody] CreateOrderCommand command)
        {
            if (command == null)
                return BadRequest("Command cannot be null");

            var result = await mediator.Send(command);

            return Ok(result);
        }
    }
}
