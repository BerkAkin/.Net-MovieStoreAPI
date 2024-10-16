using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebAPI.DBOperations;
using WebAPI.Entites;

namespace WebAPI.Application.CustomerOperations.Commands.DeleteFavoriteGenre
{
    public class DeleteFavoriteGenreCommand
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int CustomerId { get; set; }
        public DeleteFavoriteGenreViewModel Model { get; set; }
        public DeleteFavoriteGenreCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var customer = _context.Customers.Include(g => g.FavoriteGenres).SingleOrDefault(c => c.Id == CustomerId);
            if (customer is null)
            {
                throw new InvalidOperationException("Müşteri mevcut değil");
            }
            var genresToRemove = customer.FavoriteGenres.Where(g => Model.Genres.Contains(g.Id)).ToList();

            foreach (var genre in genresToRemove)
            {
                customer.FavoriteGenres.Remove(genre);
            }
            _context.SaveChanges();

        }
    }
    public class DeleteFavoriteGenreViewModel
    {
        public List<int> Genres { get; set; }
    }
}