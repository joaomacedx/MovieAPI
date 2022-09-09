using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Data;
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
        public IActionResult PostMovie([FromBody] Movie movie)
        {
            movieContext.Movies.Add(movie);
            return CreatedAtAction(nameof(GetMovie), new {Id = movie.Id}, movie);
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
               
                return Ok(movie);
            }
            return NotFound();
        }

    }
}
