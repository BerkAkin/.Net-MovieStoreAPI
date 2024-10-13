using System.Linq;
using AutoMapper;
using WebAPI.Application.MovieOperations.Commands.CreateMovie;
using WebAPI.Application.MovieOperations.Queries.GetMovieDetail;
using WebAPI.Application.MovieOperations.Queries.GetMovies;
using WebAPI.Entites;

namespace WebAPI.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, GetMoviesViewModel>()
            .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.Select(g => g.Name).ToList()));

            CreateMap<Movie, GetMovieDetailViewModel>()
            .ForMember(dest => dest.GenreList, opt => opt.MapFrom(src => src.Genres.Select(g => g.Name).ToList()));

            CreateMap<CreateMovieViewModel, Movie>().ForMember(dest => dest.Genres, opt => opt.Ignore());
            CreateMap<string, Genre>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src));

        }
    }
}