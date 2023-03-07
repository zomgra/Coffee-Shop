namespace CoffeeShop.API.Models
{
    public class CreateOrderDto
    {
        public int CoffeeId { get; set; }
        public ICollection<int> IngredientsId { get; set; }
        public string Street { get; set; }
    }
}
