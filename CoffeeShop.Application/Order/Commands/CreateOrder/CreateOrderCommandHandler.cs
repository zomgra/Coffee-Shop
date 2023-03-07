using CoffeeShop.Database;
using CoffeeShop.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Application.Order.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CoffeeOrder>
    {
        private readonly ICoffeeContext _context;

        public CreateOrderCommandHandler(ICoffeeContext context)
        {
            this._context = context;
        }
        public async Task<CoffeeOrder> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var ingredients = _context.Ingredients.Where(i => request.IngredientsId.Contains(i.Id)).ToList();
            var coffee = await _context.Coffees.FirstOrDefaultAsync(i=>i.Id == request.CoffeeId, cancellationToken);
            
            var ingrCost = ingredients.Select(s => s.Price).Sum() ;
            var coffeeCost = coffee.Cost;
            var cost = ingrCost + coffeeCost;

            var ordererCoffee = new OrderedCoffee() { Name = coffee.Name, Cost = cost, ImageUrl = coffee.ImageUrl };

            var entity = new CoffeeOrder() { Coffee = ordererCoffee, CostOrder = cost, 
                StreetOrder = request.Street, Status = OrderStatus.Open,
                UserId = request.UserId,  };

            entity.Ingredients = ingredients;

            await _context.Orders.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}
