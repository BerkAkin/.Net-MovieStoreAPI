using System;
using System.Collections.Generic;

using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.DBOperations;

namespace WebAPI.Application.CustomerOperations.Queries.GetCustomers
{
    public class GetCustomersQuery
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetCustomersQuery(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GetCustomerViewModel> Handle()
        {
            var customers = _context.Customers.Include(c => c.PurchasedMovies).Include(c => c.FavoriteGenres).ToList();
            if (customers is null)
            {
                throw new InvalidOperationException("Müşteriler bulunamadı");
            }
            List<GetCustomerViewModel> vm = _mapper.Map<List<GetCustomerViewModel>>(customers);
            return vm;
        }
    }
    public class GetCustomerViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public ICollection<string> PurchasedMovies { get; set; }
        public ICollection<string> FavoriteGenres { get; set; }
    }
}