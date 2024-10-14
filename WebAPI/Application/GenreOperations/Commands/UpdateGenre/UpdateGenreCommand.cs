using System;
using System.Linq;
using AutoMapper;
using WebAPI.DBOperations;

namespace WebAPI.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int GenreId { get; set; }
        public UpdateGenreViewModel Model { get; set; }
        public UpdateGenreCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(g => g.Id == GenreId);
            if (genre is null)
            {
                throw new InvalidOperationException("Güncellenecek tür bulunamadı");
            }
            genre.Name = Model.Name != default ? Model.Name : genre.Name;
            _context.SaveChanges();
        }
    }

    public class UpdateGenreViewModel
    {
        public string Name { get; set; }
    }
}