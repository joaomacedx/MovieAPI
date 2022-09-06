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

        [HttpPost]
        public void PostMovie([FromBody] Movie movie)
        {
            movies.Add(movie);
            Console.WriteLine(movie.Title);
        }

    }
}
