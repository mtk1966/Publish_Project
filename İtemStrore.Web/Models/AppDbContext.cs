using Microsoft.EntityFrameworkCore;

namespace İtemStrore.Web.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<İtemEntity> İtems { get; set; }
    }
}
