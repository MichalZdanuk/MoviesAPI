using Microsoft.Extensions.Caching.Memory;
using MoviesAPI.DTOs;
using MoviesAPI.Services;

namespace MoviesAPI.Decorators
{
    public class MovieServiceCacheDecorator : IMovieService
    {
        private readonly MovieService _movieService;
        private readonly IMemoryCache _cache;

        public MovieServiceCacheDecorator(MovieService movieService,
            IMemoryCache cache)
        {
            _movieService = movieService;
            _cache = cache;
        }

        public Task<Guid> CreateAsync(CreateMovieDto dto) => _movieService.CreateAsync(dto);

        public async Task<MovieDto?> GetByIdAsync(Guid id)
        {
            var cacheKey = $"movies:{id}";
            var movie = _cache.Get<MovieDto>(cacheKey);
            if(movie is null)
            {
                movie = await _movieService.GetByIdAsync(id);

                if( movie is not null)
                {
                    _cache.Set(cacheKey, movie);
                }
            }

            return movie;
        }
    }
}
