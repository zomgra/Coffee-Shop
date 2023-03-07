using CoffeeShop.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Application.Order.Commands.CancelOrder
{
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand>
    {
        private readonly ICoffeeContext _context;

        public CancelOrderCommandHandler(ICoffeeContext context)
        {
            this._context = context;
        }
        public async Task Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Orders.FirstAsync(o => o.Coffee.Id == request.OrderId, cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
                throw new Exception($"{nameof(entity)} is null or you dont have permisions to canceling");
            entity.Status = Domain.OrderStatus.Canceled;

            _context.Orders.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
