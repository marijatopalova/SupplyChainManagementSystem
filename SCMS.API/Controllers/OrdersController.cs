using MediatR;
using Microsoft.AspNetCore.Mvc;
using SCMS.Application.Dtos;
using SCMS.Application.Features.Orders.Commands.CreateOrder;
using SCMS.Application.Features.Orders.Queries.GetOrderHistory;
using SCMS.Application.Features.Orders.Queries.GetOrderStatus;

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

        /// <summary>
        /// Gets the status of the order.
        /// </summary>
        /// <param name="orderId">The ID of the order.</param>
        /// <returns>The details about the status of the order.</returns>
        [HttpGet("{orderId:guid}/status")]
        public async Task<ActionResult<OrderStatusDto>> GetOrderStatus(Guid orderId)
        {
            var query = new GetOrderStatusQuery(orderId);

            var result = await mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Gets the tracking history of the order.
        /// </summary>
        /// <param name="orderId">The ID of the order.</param>
        /// <returns>List of details about the history of the order.</returns>
        [HttpGet("{orderId:guid}/history")]
        public async Task<ActionResult<List<OrderHistoryDto>>> GetOrderHistory(Guid orderId)
        {
            var query = new GetOrderHistoryQuery(orderId);

            var result = await mediator.Send(query);

            return Ok(result);
        }
    }
}
