using jcf.billstopay.api.Models;
using Microsoft.EntityFrameworkCore;

namespace jcf.billstopay.api.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

    }
}
