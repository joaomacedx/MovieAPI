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
        public void PostMovie([FromBody] Movie movie)
        {
            movie.Id = Id++;
            movies.Add(movie);
        }
        [HttpGet]
        public IEnumerable<Movie> GetMovies()
        { 
            return movies;
        }
    }
}
