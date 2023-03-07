using CoffeeShop.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CoffeeShop.Application.Order.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderInfoVm>
    {
        private readonly ICoffeeContext _context;

        public GetOrderByIdQueryHandler(ICoffeeContext context)
        {
            _context = context;
        }
        public async Task<OrderInfoVm> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Orders.Include(o=>o.Coffee).FirstOrDefaultAsync(c=>c.Id == request.Id, cancellationToken);
            var ingredient =  entity.Ingredients;

            if (entity.UserId != request.UserId || entity == null) throw new Exception($"{nameof(entity)} is null or you dont have permisions");

            var info = new OrderInfoVm() { ImageUrl = entity.Coffee.ImageUrl,
                Cost = entity.CostOrder, OrderId = entity.Id,
                Status = entity.Status, IngredientsName = ingredient.Select(i=>i.Name).ToList() };
            
            return info;
        }
    }
}
