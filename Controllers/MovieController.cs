using AutoMapper;
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
        private IMapper movieMapper;

        public MovieController(MovieContext context, IMapper mapper)
        {
            movieContext = context;
            movieMapper = mapper;
        }

        [HttpPost]
        public IActionResult PostMovie([FromBody] CreateMovieDto movieDto)
        {
            Movie movie = movieMapper.Map<Movie>(movieDto);
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
                ReadMovieDto movieDto = movieMapper.Map<ReadMovieDto>(movie);
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
                movieMapper.Map(movieDto, movie);

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
