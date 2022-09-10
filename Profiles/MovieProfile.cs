using AutoMapper;
using MovieAPI.Data.Dto;
using MovieAPI.Models;

namespace MovieAPI.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<CreateMovieDto, Movie>();
            CreateMap<Movie, ReadMovieDto>();
            CreateMap<UpdateMovieDto, Movie>();
        }

    }
}
  