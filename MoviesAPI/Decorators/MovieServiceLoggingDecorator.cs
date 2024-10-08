using MoviesAPI.DTOs;
using MoviesAPI.Services;

namespace MoviesAPI.Decorators
{
    public class MovieServiceLoggingDecorator : IMovieService
    {
        private readonly IMovieService _service;
        private readonly ILogger<MovieServiceLoggingDecorator> _logger;

        public MovieServiceLoggingDecorator(IMovieService service,
            ILogger<MovieServiceLoggingDecorator> logger)
        {
            _service = service;
            _logger = logger;
        }

        public Task<Guid> CreateAsync(CreateMovieDto dto) => _service.CreateAsync(dto);

        public async Task<MovieDto?> GetByIdAsync(Guid id)
        {
            _logger.LogInformation($"Fetching movie with id: {id}...");
            var movie = await _service.GetByIdAsync(id);
            _logger.LogInformation($"Movie with id: {id} was {(movie is null ? "not" : "")} found.");

            return movie;
        }
    }
}
