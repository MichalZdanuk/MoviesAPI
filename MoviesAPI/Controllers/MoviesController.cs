using Microsoft.AspNetCore.Mvc;
using MoviesAPI.DTOs;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateMovie([FromBody]CreateMovieDto dto)
        {
            var id = await _movieService.CreateAsync(dto);
            return Created($"/api/movies/{id}", null);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MovieDto>> GetMovie([FromRoute]Guid id)
        {
            var movie = await _movieService.GetByIdAsync(id);

            if (movie is null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

    }
}
