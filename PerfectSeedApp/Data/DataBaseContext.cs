using Microsoft.EntityFrameworkCore;
using PerfectSeedApp.Models;

namespace PerfectSeedApp.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            
        }

        public DbSet<Seed> Calculator { get; set; }
    }
}
