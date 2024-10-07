using AutoMapper;
using MoviesAPI.DTOs;
using MoviesAPI.Entities;
using MoviesAPI.Repositories;

namespace MoviesAPI.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository,
            IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(CreateMovieDto dto)
        {
            var movie = new Movie(Guid.NewGuid(), dto.Title, dto.Description);

            await _movieRepository.AddAsync(movie);

            return movie.Id;
        }

        public async Task<MovieDto?> GetByIdAsync(Guid id)
        {
            var movie = await _movieRepository.GetAsync(id);

            var movieDto = _mapper.Map<MovieDto>(movie);

            return movieDto;
        }
    }
}
