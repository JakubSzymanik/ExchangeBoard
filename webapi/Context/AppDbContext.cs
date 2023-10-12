using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {}

        public DbSet<User> Users { get; set; }
    }
}
