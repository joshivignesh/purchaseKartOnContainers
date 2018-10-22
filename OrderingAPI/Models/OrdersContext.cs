using Microsoft.EntityFrameworkCore;

namespace OrderAPI.Models
{
    public class OrdersContext:DbContext
    {
        public OrdersContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
    }
}
