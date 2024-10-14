using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.Entites;

namespace WebAPI.DBOperations
{
    public class DbSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                if (context.Movies.Any())
                {
                    return;
                }

                Genre actionGenre = new Genre() { Name = "Action" };
                Genre comedyGenre = new Genre() { Name = "Comedy" };
                Genre horrorGenre = new Genre() { Name = "Horror" };
                Genre romanticGenre = new Genre() { Name = "Romantic" };
                context.Genres.AddRange(actionGenre, comedyGenre, horrorGenre, romanticGenre);
                context.SaveChanges();


                Actor hugh = new Actor() { Name = "Hugh", Surname = "Jackman" };
                Actor jfer = new Actor() { Name = "Jennifer", Surname = "Lawrence" };
                context.Actors.AddRange(hugh, jfer);
                context.SaveChanges();

                Producer tar = new Producer() { Name = "Quentin", Surname = "Tarantino" };
                Producer james = new Producer() { Name = "James", Surname = "Cameron" };
                context.Producers.AddRange(tar, james);


                Movie ACMovie = new Movie()
                {
                    Title = "Action Comedy Movie",
                    Price = 123,
                    Year = DateTime.Now,
                    Genres = new List<Genre> { actionGenre, comedyGenre },
                    Actors = new List<Actor> { hugh },
                    Producer = tar
                };

                Movie HRMovie = new Movie()
                {
                    Title = "Horror Romantic Movie",
                    Price = 123,
                    Year = DateTime.Now,
                    Genres = new List<Genre> { horrorGenre, romanticGenre },
                    Actors = new List<Actor> { jfer },
                    Producer = james

                };
                context.Movies.AddRange(ACMovie, HRMovie);
                context.SaveChanges();



                Customer cs1 = new Customer()
                {
                    Name = "Berk",
                    Surname = "Akın",
                    PurchasedMovies = new List<Movie> { HRMovie, ACMovie },
                    FavoriteGenres = new List<Genre> { horrorGenre, romanticGenre }
                };

                Customer cs2 = new Customer()
                {
                    Name = "Cemre",
                    Surname = "Süheyla",
                    PurchasedMovies = new List<Movie> { ACMovie },
                    FavoriteGenres = new List<Genre> { horrorGenre }
                };
                context.Customers.AddRange(cs1, cs2);
                context.SaveChanges();



                Order order1 = new Order()
                {
                    Customer = cs1,
                    Movie = HRMovie,
                    PurchaseDate = DateTime.Now,
                    Price = 124,
                };

                Order order2 = new Order()
                {
                    Customer = cs2,
                    Movie = ACMovie,
                    PurchaseDate = DateTime.Now,
                    Price = 1224,
                };

                context.Orders.AddRange(order1, order2);
                context.SaveChanges();
            }
        }
    }
}