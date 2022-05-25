using Microsoft.EntityFrameworkCore;
using Project.Shared;
namespace Project.WepApi.Models
{
    public class ECommerDB:DbContext
    {
        public ECommerDB()
        {

        }
        public ECommerDB(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }
}
