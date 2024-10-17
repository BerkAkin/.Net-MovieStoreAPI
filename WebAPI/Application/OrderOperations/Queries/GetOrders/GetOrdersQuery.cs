using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.DBOperations;
using WebAPI.Entites;

namespace WebAPI.Application.OrderOperations.Queries.GetOrders
{
    public class GetOrdersQuery
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetOrdersQuery(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GetOrdersViewModel> Handle()
        {
            var orders = _context.Orders.Include(o => o.Customer).Include(o => o.Movie).Where(o => o.IsDeleted == false).ToList();
            if (orders is null)
            {
                throw new InvalidOperationException("Siparişler bulunamadı");
            }
            List<GetOrdersViewModel> vm = _mapper.Map<List<GetOrdersViewModel>>(orders);
            return vm;

        }
    }

    public class GetOrdersViewModel
    {
        public GetOrdersMovieViewModel Movie { get; set; }
        public GetOrdersCustomerViewModel Customer { get; set; }
        public int Price { get; set; }
        public DateTime PurchaseDate { get; set; }
    }

    public class GetOrdersMovieViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class GetOrdersCustomerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}