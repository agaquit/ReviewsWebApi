using Microsoft.EntityFrameworkCore;

namespace ReviewsWebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Review> Reviews { get; set; }
    }
}
