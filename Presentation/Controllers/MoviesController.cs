using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly ILogger<MoviesController> _logger;

        public MoviesController(IMovieService movieService, ILogger<MoviesController> logger)
        {
            _movieService = movieService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MovieReadDto>> GetMovieById(int id)
        {
            _logger.LogInformation("GET request for movie {MovieId}", id);
            var movie = await _movieService.GetMoviesByIdAsync(id);

            if (movie == null)
                return NotFound(new { message = $"Movie with ID {id} not found" });

            return Ok(movie);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MovieReadDto>>> GetAllMovies()
        {
            _logger.LogInformation("GET request for all movies");
            var movies = await _movieService.GetAllMoviesAsync();
            return Ok(movies);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MovieReadDto>> CreateMovie([FromBody] MovieCreateDto movieCreateDto)
        {
            _logger.LogInformation("POST request to create movie: {Title}", movieCreateDto.Title);
            var createdMovie = await _movieService.CreateMovieAsync(movieCreateDto);
            return CreatedAtAction(nameof(GetMovieById), new { id = createdMovie.MovieId }, createdMovie);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MovieReadDto>> UpdateMovie([FromBody] MovieUpdateDto movieUpdateDto)
        {
            _logger.LogInformation("PUT request to update movie {MovieId}", movieUpdateDto.MovieId);
            var updatedMovie = await _movieService.UpdateMovieAsync(movieUpdateDto);
            return Ok(updatedMovie);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            _logger.LogInformation("DELETE request for movie {MovieId}", id);
            var result = await _movieService.DeleteMovieAsync(id);

            if (!result)
                return NotFound(new { message = $"Movie with ID {id} not found" });

            return NoContent();
        }

        [HttpGet("genre/{genre}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MovieReadDto>>> GetMoviesByGenre(string genre)
        {
            _logger.LogInformation("GET request for movies by genre: {Genre}", genre);
            var movies = await _movieService.GetMoviesByGenreAsync(genre);
            return Ok(movies);
        }

        [HttpGet("available/all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MovieReadDto>>> GetAvailableMovies()
        {
            _logger.LogInformation("GET request for available movies");
            var movies = await _movieService.GetAvailableMoviesAsync();
            return Ok(movies);
        }
    }
}
