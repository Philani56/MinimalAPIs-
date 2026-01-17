using Microsoft.EntityFrameworkCore;
using MinimalAPIs.Models;

namespace MinimalAPIs.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Person> Persons => Set<Person>();
    }
}
