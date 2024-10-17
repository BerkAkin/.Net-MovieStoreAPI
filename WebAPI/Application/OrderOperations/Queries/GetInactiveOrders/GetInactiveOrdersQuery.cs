using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.DBOperations;
using WebAPI.Entites;

namespace WebAPI.Application.OrderOperations.Queries.GetInactiveOrders
{
    public class GetInactiveOrdersQuery
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetInactiveOrdersQuery(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GetInactiveOrdersViewModel> Handle()
        {
            var orders = _context.Orders.Include(o => o.Customer).Include(o => o.Movie).Where(o => o.IsDeleted == true).ToList();
            if (orders is null)
            {
                throw new InvalidOperationException("Siparişler bulunamadı");
            }
            List<GetInactiveOrdersViewModel> vm = _mapper.Map<List<GetInactiveOrdersViewModel>>(orders);
            return vm;

        }
    }

    public class GetInactiveOrdersViewModel
    {
        public GetInactiveOrdersMovieViewModel Movie { get; set; }
        public GetInactiveOrdersCustomerViewModel Customer { get; set; }
        public int Price { get; set; }
        public DateTime PurchaseDate { get; set; }
    }

    public class GetInactiveOrdersMovieViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class GetInactiveOrdersCustomerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}