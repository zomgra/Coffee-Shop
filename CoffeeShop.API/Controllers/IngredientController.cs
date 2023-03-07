using CoffeeShop.Database;
using CoffeeShop.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    [ResponseCache(Location = ResponseCacheLocation.Client, Duration = 3600)]
    public class IngredientController : ControllerBase
    {
        private readonly CoffeeContext _context;

        public IngredientController(CoffeeContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Ingredient>>> GetAll(int id)
        {
            var needCoffe = await _context.Coffees.Include(i=>i.Ingredients).FirstOrDefaultAsync(c=>c.Id == id);
            var ingredients = needCoffe.Ingredients.ToList();
            return Ok(ingredients);
        }
    }
}
