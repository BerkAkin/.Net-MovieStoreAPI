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

                var actionGenre = new Genre { Name = "Action" };
                var comedyGenre = new Genre { Name = "Comedy" };
                var horrorGenre = new Genre { Name = "Horror" };
                var romanticGenre = new Genre { Name = "Romantic" };

                context.Genres.AddRange(actionGenre, comedyGenre);
                context.SaveChanges();


                var movie = new Movie
                {
                    Title = "Action Comedy Movie",
                    Price = 123,
                    Year = DateTime.Now,
                    Genres = new List<Genre> { actionGenre, comedyGenre }
                };

                var movie2 = new Movie
                {
                    Title = "Horror Romantic Movie",
                    Price = 123,
                    Year = DateTime.Now,
                    Genres = new List<Genre> { horrorGenre, romanticGenre }
                };


                context.Movies.AddRange(movie, movie2);
                context.SaveChanges();
            }
        }
    }
}