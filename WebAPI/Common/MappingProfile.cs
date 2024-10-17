using System.Linq;
using AutoMapper;
using WebAPI.Application.ActorOperations.Commands.CreateActor;
using WebAPI.Application.ActorOperations.Commands.UpdateActor;
using WebAPI.Application.ActorOperations.Queries.GetActorDetail;
using WebAPI.Application.ActorOperations.Queries.GetActors;
using WebAPI.Application.CustomerOperations.Commands.CreateCustomer;
using WebAPI.Application.CustomerOperations.Queries.GetCustomerDetail;
using WebAPI.Application.CustomerOperations.Queries.GetCustomers;
using WebAPI.Application.GenreOperations.Commands.CreateGenre;
using WebAPI.Application.GenreOperations.Commands.UpdateGenre;
using WebAPI.Application.GenreOperations.Queries.GetGenreDetail;
using WebAPI.Application.GenreOperations.Queries.GetGenres;
using WebAPI.Application.MovieOperations.Commands.CreateMovie;
using WebAPI.Application.MovieOperations.Queries.GetMovieDetail;
using WebAPI.Application.MovieOperations.Queries.GetMovies;
using WebAPI.Application.OrderOperations.Commands.CreateOrder;
using WebAPI.Application.OrderOperations.Commands.UpdateOrder;
using WebAPI.Application.OrderOperations.Queries.GetInactiveOrders;
using WebAPI.Application.OrderOperations.Queries.GetOrders;
using WebAPI.Application.ProducerOperations.Commands.CreateProducer;
using WebAPI.Application.ProducerOperations.Queries.GetProducerDetail;
using WebAPI.Application.ProducerOperations.Queries.GetProducers;
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



            //PRODUCER MAPPING SETTINGS
            CreateMap<Producer, GetProducerViewModel>()
            .ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.Movies.Select(m => m.Title).ToList()));

            CreateMap<Producer, GetProducerDetailViewModel>()
            .ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.Movies.Select(m => m.Title).ToList()));

            CreateMap<CreateProducerViewModel, Producer>()
            .ForMember(dest => dest.Movies, opt => opt.Ignore());


            //ACTORPRODUCER AND VICE VERSA MAPPING SETTINGS
            CreateMap<CreateActorViewModel, Producer>()
            .ForMember(dest => dest.Movies, opt => opt.Ignore())
            .ForMember(dest => dest.IsActor, opt => opt.MapFrom(src => src.IsProducer)); ;

            CreateMap<CreateProducerViewModel, Actor>()
            .ForMember(dest => dest.Movies, opt => opt.Ignore())
            .ForMember(dest => dest.IsProducer, opt => opt.MapFrom(src => src.IsActor));


            //CUSTOMER MAPPING SETTINGS
            CreateMap<Customer, GetCustomerViewModel>()
            .ForMember(dest => dest.PurchasedMovies, opt => opt.MapFrom(src => src.PurchasedMovies.Select(m => m.Title).ToList()))
            .ForMember(dest => dest.FavoriteGenres, opt => opt.MapFrom(src => src.FavoriteGenres.Select(m => m.Name).ToList()));

            CreateMap<Customer, GetCustomerDetailViewModel>()
            .ForMember(dest => dest.PurchasedMovies, opt => opt.MapFrom(src => src.PurchasedMovies.Select(m => m.Title).ToList()))
            .ForMember(dest => dest.FavoriteGenres, opt => opt.MapFrom(src => src.FavoriteGenres.Select(m => m.Name).ToList()));

            CreateMap<CreateCustomerViewModel, Customer>()
            .ForMember(dest => dest.PurchasedMovies, opt => opt.Ignore())
            .ForMember(dest => dest.FavoriteGenres, opt => opt.Ignore())
            .ForMember(dest => dest.Orders, opt => opt.Ignore());


            //ORDER MAPPING SETTINGS
            CreateMap<Order, GetOrdersViewModel>()
            .ForPath(dest => dest.Movie.Id, opt => opt.MapFrom(src => src.Movie.Id))
            .ForPath(dest => dest.Movie.Title, opt => opt.MapFrom(src => src.Movie.Title))
            .ForPath(dest => dest.Customer.Id, opt => opt.MapFrom(src => src.Customer.Id))
            .ForPath(dest => dest.Customer.Name, opt => opt.MapFrom(src => src.Customer.Name + " " + src.Customer.Surname))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.PurchaseDate, opt => opt.MapFrom(src => src.PurchaseDate));

            CreateMap<Order, GetInactiveOrdersViewModel>()
            .ForPath(dest => dest.Movie.Id, opt => opt.MapFrom(src => src.Movie.Id))
            .ForPath(dest => dest.Movie.Title, opt => opt.MapFrom(src => src.Movie.Title))
            .ForPath(dest => dest.Customer.Id, opt => opt.MapFrom(src => src.Customer.Id))
            .ForPath(dest => dest.Customer.Name, opt => opt.MapFrom(src => src.Customer.Name + " " + src.Customer.Surname))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.PurchaseDate, opt => opt.MapFrom(src => src.PurchaseDate));



            CreateMap<Order, GetOrderDetailViewModel>()
           .ForPath(dest => dest.Movie.Id, opt => opt.MapFrom(src => src.Movie.Id))
           .ForPath(dest => dest.Movie.Title, opt => opt.MapFrom(src => src.Movie.Title))
           .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
           .ForMember(dest => dest.PurchaseDate, opt => opt.MapFrom(src => src.PurchaseDate));



            CreateMap<CreateOrderViewModel, Order>()
            .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
            .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.MovieId))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.PurchaseDate, opt => opt.MapFrom(src => src.PurchaseDate));



        }
    }
}