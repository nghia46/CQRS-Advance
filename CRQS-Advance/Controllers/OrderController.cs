using Commands.Command;
using MediatR;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Queries.Query;

namespace CRQSAdvance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ISender _sender;
        public OrderController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _sender.Send(new GetOrdersQuery()));
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateOrderCommand command)
        {
            return Ok(await _sender.Send(command));
        }
    }
}
