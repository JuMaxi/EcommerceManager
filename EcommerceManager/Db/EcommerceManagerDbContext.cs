using EcommerceManager.Models.DataBase;
using Microsoft.EntityFrameworkCore;

namespace EcommerceManager.Db
{
    public class EcommerceManagerDbContext : DbContext
    {
        public EcommerceManagerDbContext(DbContextOptions<EcommerceManagerDbContext> options) : base(options) { }

        public DbSet<CategoryRequest> Categories { get; set; }
    }
}
