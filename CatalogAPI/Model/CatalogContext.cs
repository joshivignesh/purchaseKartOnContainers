using Microsoft.EntityFrameworkCore;

namespace CatalogAPI.Model
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options ) : base(options) { }

        public DbSet<CatalogContext> catalog { get; set; }

    }
}
