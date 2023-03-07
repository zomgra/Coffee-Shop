using MediatR;

namespace CoffeeShop.Application.Order.Commands.PayOrder
{
    public class PayOrderCommand : IRequest
    {
        public Guid UserId { get; set; }
        public int OrderId { get; set; }
    }
}
