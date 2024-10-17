using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.DBOperations;
using WebAPI.Entites;

namespace WebAPI.Application.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommand
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateOrderViewModel Model { get; set; }
        public CreateOrderCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var order = _mapper.Map<Order>(Model);
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Model.MovieId);
            var customer = _context.Customers.Include(m => m.PurchasedMovies).SingleOrDefault(c => c.Id == Model.CustomerId);
            customer.PurchasedMovies.Add(movie);
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }

    public class CreateOrderViewModel
    {

        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public int Price { get; set; }
        public DateTime PurchaseDate = DateTime.Now;
    }
}