using System.Linq;
using AutoMapper;
using WebAPI.Application.ActorOperations.Commands.CreateActor;
using WebAPI.Application.ActorOperations.Commands.UpdateActor;
using WebAPI.Application.ActorOperations.Queries.GetActorDetail;
using WebAPI.Application.ActorOperations.Queries.GetActors;
using WebAPI.Application.GenreOperations.Commands.CreateGenre;
using WebAPI.Application.GenreOperations.Commands.UpdateGenre;
using WebAPI.Application.GenreOperations.Queries.GetGenreDetail;
using WebAPI.Application.GenreOperations.Queries.GetGenres;
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

            //MOVIE MAPPING SETTINGS
            CreateMap<Movie, GetMoviesViewModel>()
            .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.Select(g => g.Name).ToList()))
            .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.Actors.Select(g => g.Name + " " + g.Surname).ToList()))
            .ForMember(dest => dest.Producer, opt => opt.MapFrom(src => src.Producer.Name + " " + src.Producer.Surname));

            CreateMap<Movie, GetMovieDetailViewModel>()
            .ForMember(dest => dest.GenreList, opt => opt.MapFrom(src => src.Genres.Select(g => g.Name).ToList()))
            .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.Actors.Select(g => g.Name + " " + g.Surname).ToList()))
            .ForMember(dest => dest.Producer, opt => opt.MapFrom(src => src.Producer.Name + " " + src.Producer.Surname));

            CreateMap<CreateMovieViewModel, Movie>()
            .ForMember(dest => dest.Genres, opt => opt.Ignore())
            .ForMember(dest => dest.Producer, opt => opt.Ignore())
            .ForMember(dest => dest.ProducerId, opt => opt.Ignore())
            .ForMember(dest => dest.Actors, opt => opt.Ignore());

            CreateMap<string, Genre>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src));





            //GENRE MAPPING SETTINGS
            CreateMap<Genre, GetGenresViewModel>()
            .ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.Movies.Select(m => m.Title).ToList()));

            CreateMap<Genre, GetGenreDetailViewModel>()
            .ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.Movies.Select(m => m.Title).ToList()));

            CreateMap<CreateGenreViewModel, Genre>();
            CreateMap<UpdateGenreViewModel, Genre>();





            //ACTOR MAPPING SETTINGS
            CreateMap<Actor, GetActorsViewModel>()
            .ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.Movies.Select(m => m.Title).ToList()));

            CreateMap<Actor, GetActorDetailViewModel>()
            .ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.Movies.Select(m => m.Title).ToList()));

            CreateMap<CreateActorViewModel, Actor>().ForMember(dest => dest.Movies, opt => opt.Ignore());
            CreateMap<UpdateActorViewModel, Actor>();

        }
    }
}