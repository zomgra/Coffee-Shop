using MediatR;

namespace CoffeeShop.Application.Order.Commands.CancelOrder
{
    public class CancelOrderCommand : IRequest
    {
        public int OrderId { get; set; }
        public Guid UserId { get; set; }
    }
}
