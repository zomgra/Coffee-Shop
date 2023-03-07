using CoffeeShop.Domain;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Database
{
    public class CoffeeContext : DbContext, ICoffeeContext
    {
        public CoffeeContext(DbContextOptions<CoffeeContext> options) : base(options)
        {

        }

        public DbSet<Coffee> Coffees { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<CoffeeOrder> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coffee>()
            .HasMany(r => r.Ingredients)
            .WithMany()
            .UsingEntity(j => j.ToTable("CoffeeIngredients"));

            modelBuilder.Entity<CoffeeOrder>()
                .HasMany(c => c.Ingredients)
                .WithMany()
                .UsingEntity(j => j.ToTable("OrderIngredients"));
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
