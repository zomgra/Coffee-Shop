using CoffeeShop.API.Models;
using CoffeeShop.Application.Order.Commands.CancelOrder;
using CoffeeShop.Application.Order.Commands.CreateOrder;
using CoffeeShop.Application.Order.Commands.PayOrder;
using CoffeeShop.Database;
using CoffeeShop.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : BaseController
    {
        private readonly ICoffeeContext _ordersContext;

        public OrdersController(ICoffeeContext ordersContext)
        {
            _ordersContext = ordersContext;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CoffeeOrder>> GetById(int id)
        {
            var entity = _ordersContext.Orders.Include(i => i.Ingredients).Where(i => i.Id == id).Include(i=>i.Coffee) as CoffeeOrder;
            if(entity.UserId == UserId)
                return Ok(entity);
            return Problem(statusCode: 400);
        }
        [HttpGet]
        public async Task<ActionResult<List<CoffeeOrder>>> GetByUserId()
        {
            var entity = await _ordersContext.Orders.Include(i => i.Ingredients).Include(i => i.Coffee).Where(i=>i.UserId == UserId) .ToListAsync();
            
            return entity;
        }
        [HttpPost("create")]
        public async Task<ActionResult<CoffeeOrder>> CreateOrderAsync([FromBody]CreateOrderDto value)
        {
            var command = new CreateOrderCommand { UserId = UserId, CoffeeId = value.CoffeeId, IngredientsId = value.IngredientsId, Street = value.Street };
            var order = await Mediator.Send(command);
            return Ok(order);
        }
        [HttpPut("pay")]
        public async Task<IActionResult> PayOrderAsync([FromBody] PayOrderDto value)
        {
            var command = new PayOrderCommand() { OrderId = value.Id, UserId = UserId };
            await Mediator.Send(command);
            return Ok();
        }
        [HttpPut("cancel")]
        public async Task<IActionResult> CancelOrderAsync([FromBody] CancelOrderDto value)
        {
            var command = new CancelOrderCommand() { UserId = UserId, OrderId = value.Id };
            await Mediator.Send(command);
            return Ok();
        }
    }
}
