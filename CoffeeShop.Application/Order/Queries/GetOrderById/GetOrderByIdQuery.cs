using CoffeeShop.Domain;
using MediatR;

namespace CoffeeShop.Application.Order.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<OrderInfoVm>
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
    }
}
