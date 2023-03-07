using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop.Domain
{
    public class CoffeeOrder
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public OrderedCoffee Coffee { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
        public decimal CostOrder { get; set; }
        public string StreetOrder { get; set; }
        public OrderStatus Status { get; set; }
    }
    public enum OrderStatus
    {
        Open,
        Canceled,
        Payed,
    }
}
