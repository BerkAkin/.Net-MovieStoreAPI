using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.DBOperations;
using WebAPI.Entites;

namespace WebAPI.Application.OrderOperations.Commands.DeleteOrder
{
    public class DeleteOrderCommand
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int OrderId { get; set; }
        public DeleteOrderCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var order = _context.Orders.Include(o => o.Customer).SingleOrDefault(o => o.Id == OrderId);
            order.IsDeleted = true;
            var customer = _context.Customers.Include(c => c.PurchasedMovies).SingleOrDefault(o => o.Id == order.CustomerId);
            var movie = _context.Movies.SingleOrDefault(o => o.Id == order.MovieId);
            customer.PurchasedMovies.Remove(movie);
            _context.SaveChanges();
        }
    }


}