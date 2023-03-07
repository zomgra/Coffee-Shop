using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.IdentityServer
{
    public class DbInitialize
    {
        public static void Initial(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
