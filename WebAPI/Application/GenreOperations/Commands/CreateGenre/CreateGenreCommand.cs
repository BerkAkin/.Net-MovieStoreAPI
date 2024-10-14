using System.Collections.Generic;
using AutoMapper;
using WebAPI.DBOperations;
using WebAPI.Entites;

namespace WebAPI.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        private readonly IMapper _mapper;
        private readonly MovieStoreDbContext _context;
        public CreateGenreViewModel Model { get; set; }
        public CreateGenreCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var genre = _mapper.Map<Genre>(Model);
            _context.Genres.Add(genre);
            _context.SaveChanges();

        }
    }

    public class CreateGenreViewModel
    {
        public string Name { get; set; }
    }
}