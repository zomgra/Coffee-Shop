using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Domain
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
