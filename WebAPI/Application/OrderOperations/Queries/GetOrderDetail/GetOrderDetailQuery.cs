using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.DBOperations;
using WebAPI.Entites;

namespace WebAPI.Application.OrderOperations.Queries.GetOrders
{
    public class GetOrderDetailQuery
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int CustomerId { get; set; }
        public GetOrderDetailQuery(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetOrderDetailViewModel> Handle()
        {
            var orders = _context.Orders.Include(o => o.Movie).Where(c => c.Customer.Id == CustomerId).Where(o => o.IsDeleted == false).ToList();
            if (orders is null)
            {
                throw new InvalidOperationException("Kullanıcıya ait sipariş bulunamadı");
            }
            List<GetOrderDetailViewModel> vm = _mapper.Map<List<GetOrderDetailViewModel>>(orders);
            return vm;

        }
    }

    public class GetOrderDetailViewModel
    {
        public GetOrderDetailMovieViewModel Movie { get; set; }
        public int Price { get; set; }
        public DateTime PurchaseDate { get; set; }
    }

    public class GetOrderDetailMovieViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

}