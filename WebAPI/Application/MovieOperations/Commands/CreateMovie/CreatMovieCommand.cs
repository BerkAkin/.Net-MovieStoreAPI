using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebAPI.DBOperations;
using WebAPI.Entites;

namespace WebAPI.Application.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommand
    {
        private readonly IMapper _mapper;
        private readonly MovieStoreDbContext _context;

        public CreateMovieViewModel Model { get; set; }


        public CreateMovieCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Title == Model.Title);

            if (movie is not null)
            {
                throw new InvalidOperationException("Eklemeye Çalıştığınız Film Zaten Mevcut. Lütfen Başka Bir Film Başlığı Deneyin");
            }
            movie = _mapper.Map<Movie>(Model);

            var genres = _context.Genres.Where(g => Model.Genres.Contains(g.Id)).ToList();
            var producer = _context.Producers.Where(p => p.Id == Model.ProducerId).SingleOrDefault();
            var actors = _context.Actors.Where(a => Model.Actors.Contains(a.Id)).ToList();

            /*string[] FullName = new string[2];
              FullName = Model.Producer.Split(" ");
            AD SOYAD BİLGİSİNDEN PRODUCER ID BULUNMASI VE ATAMA YAPILMASI. FRONT-END TARAFINDA BÖYLE OLACAK MANTIKEN
            var producer = _context.Producers.SingleOrDefault(p => p.Name == FullName[0] && p.Surname == FullName[1]); */

            movie.Genres = genres;
            movie.ProducerId = producer.Id;
            movie.Actors = actors;

            if (movie.Genres == null || !movie.Genres.Any())
            {
                throw new InvalidOperationException("Bir filmin en az bir türü olmalıdır");
            }

            if (movie.Actors == null || !movie.Actors.Any())
            {
                throw new InvalidOperationException("Bir filmin en az bir oyuncusu olmalıdır");
            }


            _context.Add(movie);
            _context.SaveChanges();

        }
    }

    public class CreateMovieViewModel
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public DateTime Year { get; set; }
        public List<int> Genres { get; set; }
        public List<int> Actors { get; set; }
        public int ProducerId { get; set; }

    }
}