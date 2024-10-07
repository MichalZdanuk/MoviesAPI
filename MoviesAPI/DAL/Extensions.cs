using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;

namespace MoviesAPI.DAL
{
    public static class Extensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<MoviesDbContext>(options =>
            options.UseSqlServer(connectionString));
        }
    }
}
