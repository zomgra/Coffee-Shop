using CoffeeShop.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Application.Order.Commands.PayOrder
{
    public class PayOrderCommandHandler : IRequestHandler<PayOrderCommand>
    {
        private readonly ICoffeeContext _context;

        public PayOrderCommandHandler(ICoffeeContext context)
        {
            this._context = context;
        }
        public async Task Handle(PayOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Orders.FirstAsync(o=>o.Coffee.Id == request.OrderId, cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
                throw new Exception($"{nameof(entity)} is null or you dont have permisions to pay");
            entity.Status = Domain.OrderStatus.Payed;

            _context.Orders.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
