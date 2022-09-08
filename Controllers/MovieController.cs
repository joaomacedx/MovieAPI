using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Models;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private static List<Movie> movies = new List<Movie>();
        private static int Id = 1;

        [HttpPost]
        public IActionResult PostMovie([FromBody] Movie movie)
        {
            movie.Id = Id++;
            movies.Add(movie);
            return CreatedAtAction(nameof(GetMovie), new {Id = movie.Id}, movie);
        }
        [HttpGet]
        public IActionResult GetMovies()
        {
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovie(int Id)
        {
            Movie movie = movies.FirstOrDefault(movie => movie.Id == Id);
            if (movie != null)
            {
               
                return Ok(movie);
            }
            return NotFound();
        }

    }
}
