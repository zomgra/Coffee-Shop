namespace CoffeeShop.Domain
{
    public class OrderedCoffee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public decimal Cost { get; set; }
    }
}
