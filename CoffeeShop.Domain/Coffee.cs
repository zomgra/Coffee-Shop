using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Domain
{
    public class Coffee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public decimal  Cost { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
    }
}
