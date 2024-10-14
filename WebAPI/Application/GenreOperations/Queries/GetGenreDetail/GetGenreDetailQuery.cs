using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.DBOperations;
using WebAPI.Entites;

namespace WebAPI.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        private readonly IMapper _mapper;
        private readonly MovieStoreDbContext _context;
        public int GenreId { get; set; }
        public GetGenreDetailQuery(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetGenreDetailViewModel Handle()
        {
            var genre = _context.Genres.Include(m => m.Movies).Where(g => g.Id == GenreId).SingleOrDefault();
            if (genre is null)
            {
                throw new InvalidOperationException("Genre bulunamadı");
            }
            else
            {
                GetGenreDetailViewModel vm = _mapper.Map<GetGenreDetailViewModel>(genre);
                return vm;
            }
        }
    }

    public class GetGenreDetailViewModel
    {
        public string Name { get; set; }
        public ICollection<string> Movies { get; set; }
    }
}