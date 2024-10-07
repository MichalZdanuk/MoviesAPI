using MoviesAPI.Entities;

namespace MoviesAPI.Repositories
{
    public interface IMovieRepository
    {
        public Task<Movie?> GetAsync(Guid id);
        public Task AddAsync(Movie movie);
    }
}
