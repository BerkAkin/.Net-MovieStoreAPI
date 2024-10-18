using System;
using System.Linq;
using AutoMapper;
using WebAPI.DBOperations;

namespace WebAPI.Application.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommand
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }
        public DeleteMovieCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == Id);
            if (movie is null)
            {
                throw new InvalidOperationException("Silinecek film bulunamadı");
            }
            else
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
        }
    }
}