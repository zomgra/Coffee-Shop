using CoffeeShop.Database;
using CoffeeShop.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        private readonly CoffeeContext _context;

        public CoffeeController(CoffeeContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Coffee>>> GetCoffee()
        {
            var coffees = await _context.Coffees.ToListAsync();
            return Ok(coffees);
        }
    }
}
