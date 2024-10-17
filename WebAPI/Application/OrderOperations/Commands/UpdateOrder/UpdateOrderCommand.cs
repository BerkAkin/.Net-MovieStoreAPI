using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.DBOperations;
using WebAPI.Entites;

namespace WebAPI.Application.OrderOperations.Commands.UpdateOrder
{
    public class UpdateOrderCommand
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int OrderId { get; set; }
        public UpdateOrderViewModel Model { get; set; }
        public UpdateOrderCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var order = _context.Orders.SingleOrDefault(o => o.Id == OrderId);
            order.CustomerId = Model.CustomerId != default ? Model.CustomerId : order.CustomerId;
            order.MovieId = Model.MovieId != default ? Model.MovieId : order.MovieId;
            order.Price = Model.Price != default ? Model.Price : order.Price;

            _context.SaveChanges();

        }
    }

    public class UpdateOrderViewModel
    {

        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public int Price { get; set; }
    }
}