using API_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Task.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Country> Countries { get; set; }
    }
}
