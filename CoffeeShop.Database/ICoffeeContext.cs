using CoffeeShop.Domain;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Database
{
    public interface ICoffeeContext
    {
        DbSet<Coffee> Coffees { get; set; }
        DbSet<Ingredient> Ingredients { get; set; }
        DbSet<CoffeeOrder> Orders { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
