using MediatR;

namespace CoffeeShop.Application.Order.Queries.GetOrdersByUserId
{
    public class GetOrdersByUserIdQueryHandler : IRequestHandler<GetOrdersByUserIdQuery, OrdersInfoVm>
    {
        public Task<OrdersInfoVm> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
