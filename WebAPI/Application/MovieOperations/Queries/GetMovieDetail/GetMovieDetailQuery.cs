using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.DBOperations;

namespace WebAPI.Application.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQuery
    {
        private readonly IMapper _mapper;
        private readonly MovieStoreDbContext _context;
        public int MovieId { get; set; }
        public GetMovieDetailQuery(MovieStoreDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public GetMovieDetailViewModel Handle()
        {
            var movie = _context.Movies.Include(m => m.Genres).Where(x => x.Id == MovieId).SingleOrDefault();
            GetMovieDetailViewModel vm = _mapper.Map<GetMovieDetailViewModel>(movie);
            return vm;
        }
    }

    public class GetMovieDetailViewModel
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public DateTime Year { get; set; }
        public List<string> GenreList { get; set; }
    }
}