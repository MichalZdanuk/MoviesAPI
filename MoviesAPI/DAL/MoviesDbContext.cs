using Microsoft.EntityFrameworkCore;
using MoviesAPI.DAL.Configurations;
using MoviesAPI.Entities;

namespace MoviesAPI.Data
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieConfiguration).Assembly);
        }
    }
}
