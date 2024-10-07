using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Entities;

namespace MoviesAPI.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MoviesDbContext _dbContext;

        public MovieRepository(MoviesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Movie movie)
        {
            await _dbContext.Set<Movie>().AddAsync(movie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Movie?> GetAsync(Guid id)
        {
            return await _dbContext.Set<Movie>().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
