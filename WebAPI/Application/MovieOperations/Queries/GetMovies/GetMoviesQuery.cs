using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DBOperations;
using WebAPI.Entites;
using System.Linq;

namespace WebAPI.Application.MovieOperations.Queries.GetMovies
{
    public class GetMoviesQuery
    {
        private readonly IMapper _mapper;
        private readonly MovieStoreDbContext _context;

        public GetMoviesQuery(MovieStoreDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public List<GetMoviesViewModel> Handle()
        {
            var movies = _context.Movies.Include(m => m.Genres).Include(a => a.Actors).Include(p => p.Producer).ToList();
            List<GetMoviesViewModel> movieListModel = _mapper.Map<List<GetMoviesViewModel>>(movies);
            return movieListModel;
        }
    }

    public class GetMoviesViewModel
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public DateTime Year { get; set; }
        public List<string> Genres { get; set; }
        public List<string> Actors { get; set; }
        public string Producer { get; set; }

    }
}