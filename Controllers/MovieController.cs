using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Data;
using MovieAPI.Data.Dto;
using MovieAPI.Models;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private MovieContext movieContext;

        public MovieController(MovieContext context)
        {
            movieContext = context;
        }

        [HttpPost]
        public IActionResult PostMovie([FromBody] CreateMovieDto movieDto)
        {
            Movie movie = new Movie()
            {
                Title = movieDto.Title,
                Director = movieDto.Director,
                Gender = movieDto.Gender,
                Duration = movieDto.Duration
            };
            movieContext.Movies.Add(movie);
            movieContext.SaveChanges();
            return CreatedAtAction(nameof(GetMovie), new { Id = movie.Id }, movie);
        }
        [HttpGet]
        public IEnumerable<Movie> GetMovies()
        {
            return movieContext.Movies;
        }

        [HttpGet("{id}")]
        public IActionResult GetMovie(int Id)
        {
            Movie movie = movieContext.Movies.FirstOrDefault(movie => movie.Id == Id);
            if (movie != null)
            {
                ReadMovieDto movieDto = new ReadMovieDto
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Director = movie.Director,
                    Gender = movie.Gender,
                    Duration = movie.Duration,
                    consultationTime = DateTime.Now
                };
                return Ok(movieDto);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPut("{id}")]
        public IActionResult PutMovie(int Id, [FromBody] UpdateMovieDto movieDto)
        {
            Movie movie = movieContext.Movies.FirstOrDefault(movie => movie.Id == Id);
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                movie.Title = movieDto.Title;
                movie.Director = movieDto.Director;
                movie.Gender = movieDto.Gender;
                movie.Duration = movieDto.Duration;

                movieContext.SaveChanges();
                return NoContent();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int Id)
        {
            Movie movie = movieContext.Movies.FirstOrDefault(movie => movie.Id == Id);
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                movieContext.Remove(movie);
                movieContext.SaveChanges();
                return NoContent();
            }
        }
    }
}
