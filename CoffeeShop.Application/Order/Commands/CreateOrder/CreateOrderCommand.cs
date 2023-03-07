using CoffeeShop.Domain;
using MediatR;

namespace CoffeeShop.Application.Order.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<CoffeeOrder>
    {
        public int CoffeeId { get; set; }
        public ICollection<int> IngredientsId { get; set; }
        public Guid UserId { get; set; }
        public string Street { get; set; }
    }
}
