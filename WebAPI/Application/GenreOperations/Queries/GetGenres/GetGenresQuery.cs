using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.DBOperations;


namespace WebAPI.Application.GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {

        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetGenresQuery(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetGenresViewModel> Handle()
        {
            var genres = _context.Genres.Include(m => m.Movies).ToList();
            if (genres is null)
            {
                throw new InvalidOperationException("Türler Bulunamadı");
            }
            else
            {
                List<GetGenresViewModel> vm = _mapper.Map<List<GetGenresViewModel>>(genres);
                return vm;
            }
        }
    }

    public class GetGenresViewModel
    {
        public string Name { get; set; }
        public ICollection<string> Movies { get; set; }
    }
}