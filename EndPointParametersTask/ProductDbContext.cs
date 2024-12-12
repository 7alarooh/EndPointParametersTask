using EndPointParametersTask.Models;
using Microsoft.EntityFrameworkCore;

namespace EndPointParametersTask
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
