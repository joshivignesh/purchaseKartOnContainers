using Microsoft.EntityFrameworkCore;

namespace BasketAPI.Model
{
    public class BasketContext: DbContext
    {
        public BasketContext(DbContextOptions<BasketContext> options) :base(options) { }

        public DbSet<Basket> blog { get; set; }
    }
}
