using MediatR;

namespace CoffeeShop.Application.Order.Queries.GetOrdersByUserId
{
    public class GetOrdersByUserIdQuery : IRequest<OrdersInfoVm>
    {
        public Guid UserId { get; set; }
    }
}
