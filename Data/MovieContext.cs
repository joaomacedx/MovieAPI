using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;

namespace MovieAPI.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> opt) : base(opt)
        {

        }
        public DbSet<Movie> Movies { get; set; }
    }
}
