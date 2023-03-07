using CoffeeShop.Database;
using CoffeeShop.Domain;

namespace CoffeeShop.API
{
    public class DbInitializer
    {
        public static void Initialize(IServiceScope services)
        {
            var coffeeDb = services.ServiceProvider.GetService<CoffeeContext>();
            var ingredients = new List<Ingredient>()
            {
                new Ingredient{Name = "Lime", Price = 2},
                new Ingredient{Name = "Sugar x2", Price = 1},
                new Ingredient{Name = "Cookie", Price = 6},
                new Ingredient{Name = "Cake", Price = 10},
                new Ingredient{Name = "VIP coupon", Price = 200},
            };
            var coffees = new List<Coffee>()
            {
                new Coffee{
                    ImageUrl = "data:image/jpeg;base64,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",
                    Cost = 200, Ingredients = new[]{ingredients[0],ingredients[3]},
                    Name = "Latte",
                },
                new Coffee{
                  Cost = 190,
                  Ingredients = new[]{ingredients[4],ingredients[1], ingredients[0] },
                  Name = "Cappuccino",
                  ImageUrl = "https://www.thespruceeats.com/thmb/oUxhx54zsjVWfPlrgedJU0MZ-y0=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/how-to-make-cappuccinos-766116-hero-01-a754d567739b4ee0b209305138ecb996.jpg",

                },
                new Coffee
                {
                    Cost = 500,
                    Ingredients = new List<Ingredient>(ingredients),
                    Name = "Ice Laate",
                    ImageUrl = "https://www.baristainstitute.com/sites/default/files/styles/some_share/public/images/Tazza_Ice_Latte.jpg?itok=V-dEBL6t"
                }
            };
            if (!coffeeDb.Ingredients.Any())
            {
                coffeeDb.Ingredients.AddRange(ingredients);
                coffeeDb.SaveChanges();
            }
            if (!coffeeDb.Coffees.Any())
            {
                coffeeDb.Coffees.AddRange(coffees);
                coffeeDb.SaveChanges();
            }
        }
    }
}
