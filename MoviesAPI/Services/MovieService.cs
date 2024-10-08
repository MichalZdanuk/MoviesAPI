using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using MoviesAPI.DTOs;
using MoviesAPI.Entities;
using MoviesAPI.Repositories;

namespace MoviesAPI.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly TimeSpan _cacheDuration = TimeSpan.FromMinutes(5);

        public MovieService(IMovieRepository movieRepository,
            IMapper mapper,
            IMemoryCache cache)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<Guid> CreateAsync(CreateMovieDto dto)
        {
            var movie = new Movie(Guid.NewGuid(), dto.Title, dto.Description);

            await _movieRepository.AddAsync(movie);

            return movie.Id;
        }

        public async Task<MovieDto?> GetByIdAsync(Guid id)
        {
            var dto = _cache.Get<MovieDto>($"movies:{id}");

            if(dto is not null)
            {
                return dto;
            }

            var movie = await _movieRepository.GetAsync(id);

            if(movie is null)
            {
                return null;
            }

            var movieDto = _mapper.Map<MovieDto>(movie);

            _cache.Set($"movies:{id}", movieDto, _cacheDuration);

            return movieDto;
        }
    }
}
