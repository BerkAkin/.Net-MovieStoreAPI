using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebAPI.DBOperations;
using WebAPI.Entites;

namespace WebAPI.Application.CustomerOperations.Commands.AddFavoriteGenre
{
    public class AddFavoriteGenreCommand
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int CustomerId { get; set; }
        public AddFavoriteGenreViewModel Model { get; set; }
        public AddFavoriteGenreCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == CustomerId);
            if (customer is null)
            {
                throw new InvalidOperationException("Müşteri Bulunamadı");

            }
            customer.FavoriteGenres = _context.Genres.Where(g => Model.Genres.Contains(g.Id)).ToList();
            _context.SaveChanges();
        }
    }
    public class AddFavoriteGenreViewModel
    {
        public List<int> Genres { get; set; }
    }
}