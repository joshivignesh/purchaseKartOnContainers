using CatalogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogAPI.Infrastructure
{
    public class CatalogContext:DbContext
    {
        public CatalogContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Prodcuts { get; set; }
    }
}
