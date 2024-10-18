using System;
using System.Collections.Generic;

using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.DBOperations;

namespace WebAPI.Application.CustomerOperations.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQuery
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }
        public GetCustomerDetailQuery(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GetCustomerDetailViewModel Handle()
        {
            var customer = _context.Customers.Include(c => c.PurchasedMovies).Include(c => c.FavoriteGenres).SingleOrDefault(c => c.Id == Id);
            if (customer is null)
            {
                throw new InvalidOperationException("Müşteri bulunamadı");
            }
            GetCustomerDetailViewModel vm = _mapper.Map<GetCustomerDetailViewModel>(customer);
            return vm;
        }
    }
    public class GetCustomerDetailViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public ICollection<string> PurchasedMovies { get; set; }
        public ICollection<string> FavoriteGenres { get; set; }
    }
}