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


                context.Movies.AddRange(
                    new Movie
                    {
                        Title = "Action Comedy Movie",
                        Price = 123,
                        Year = DateTime.Now,
                        Genres = new List<Genre> { actionGenre, comedyGenre },
                        Actors = new List<Actor> { hugh }
                    },
                    new Movie
                    {
                        Title = "Horror Romantic Movie",
                        Price = 123,
                        Year = DateTime.Now,
                        Genres = new List<Genre> { horrorGenre, romanticGenre },
                        Actors = new List<Actor> { jfer }
                    }
                );

                context.SaveChanges();
            }
        }
    }
}