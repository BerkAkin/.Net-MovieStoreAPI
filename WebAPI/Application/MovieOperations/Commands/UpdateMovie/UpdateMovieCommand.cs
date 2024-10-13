using System;
using System.Collections.Generic;

using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.DBOperations;

namespace WebAPI.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommand
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public UpdateMovieViewModel Model { get; set; }
        public int Id { get; set; }
        public UpdateMovieCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var movie = _context.Movies.Include(x => x.Genres).Where(x => x.Id == Id).SingleOrDefault();
            if (movie is null)
            {
                throw new InvalidOperationException("Güncellenecek kitap bulunamadı");
            }
            else
            {
                movie.Title = Model.Title != default ? Model.Title : movie.Title;
                movie.Price = Model.Price != default ? Model.Price : movie.Price;
                movie.Year = Model.Year != default ? Model.Year : movie.Year;


                if (Model.Genres != null && Model.Genres.Count > 0)
                {
                    movie.Genres.Clear();
                    foreach (var genreName in Model.Genres)
                    {
                        var genre = _context.Genres.SingleOrDefault(g => g.Name.ToLower() == genreName.ToLower());
                        if (genre is null)
                        {
                            throw new InvalidOperationException("Genre'yı Listedekilerden seçin");
                        }
                        else
                        {
                            movie.Genres.Add(genre);
                        }



                    }
                }
                _context.SaveChanges();
            }
        }
    }
    public class UpdateMovieViewModel
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public DateTime Year { get; set; }
        public List<string> Genres { get; set; }
    }
}