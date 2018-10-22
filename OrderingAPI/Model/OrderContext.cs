using Microsoft.EntityFrameworkCore;

namespace OrderingAPI.Model
{
    public class OrderContext:DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options) { }

        public DbSet<OrderContext> order { get; set; }
    }
}
