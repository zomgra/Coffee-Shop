using CoffeeShop.Domain;

namespace CoffeeShop.Application.Order.Queries.GetOrderById
{
    public class OrderInfoVm
    {
        public int OrderId { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<string> IngredientsName { get; set; }
        public decimal Cost { get; set; }
        public OrderStatus Status { get; set; }
    }
}
