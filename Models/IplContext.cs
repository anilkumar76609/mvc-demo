
using Microsoft.EntityFrameworkCore;

namespace MVCDemo3.Models
{

    public class IplContext : DbContext
    {
        public IplContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<IPL> IPLs { get; set; }
    }
}