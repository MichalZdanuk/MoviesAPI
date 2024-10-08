using MoviesAPI.DTOs;

namespace MoviesAPI.Services
{
    public interface IMovieService
    {
        Task<Guid> CreateAsync(CreateMovieDto dto);
        Task<MovieDto?> GetByIdAsync(Guid id);
    }
}
