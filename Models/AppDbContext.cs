using littlesipper_api;
using Microsoft.EntityFrameworkCore;

namespace ChildFriendlyCafes.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<CafeInformation> Cafes { get; set; }
    }
}
