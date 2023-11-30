using Microsoft.EntityFrameworkCore;

namespace littlesipper_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<CafeInformation> Cafes { get; set; }
    }
}