using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.DBOperations;
using WebAPI.Entites;

namespace WebAPI.Application.OrderOperations.Commands.SetOrderAtatusActive
{
    public class SetOrderStatusActiveCommand
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int OrderId { get; set; }
        public SetOrderStatusActiveCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var order = _context.Orders.SingleOrDefault(o => o.Id == OrderId);
            if (order.IsDeleted == false)
            {
                throw new InvalidOperationException("Durum zaten true değerlikli");
            }
            order.IsDeleted = !order.IsDeleted;
            _context.SaveChanges();
        }
    }

}