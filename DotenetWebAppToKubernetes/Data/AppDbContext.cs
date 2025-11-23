using Microsoft.EntityFrameworkCore;
using DotnetWebAppToKubernetes.Models;

namespace DotnetWebAppToKubernetes.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
    }
}
