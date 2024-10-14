using System;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using WebAPI.DBOperations;
using WebAPI.Entites;

namespace WebAPI.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int GenreId { get; set; }
        public DeleteGenreCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var genre = _context.Genres.Include(m => m.Movies).SingleOrDefault(g => g.Id == GenreId);
            if (genre is null)
            {
                throw new InvalidOperationException("Silinmek istenen tür bulunamadı.");
            }
            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }
    }
}