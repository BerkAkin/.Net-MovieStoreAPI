using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebAPI.DBOperations;
using WebAPI.Entites;

namespace WebAPI.Application.CustomerOperations.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public UpdateCustomerViewModel Model { get; set; }
        public int Id { get; set; }
        public UpdateCustomerCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public void Handle()
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customer is null)
            {
                throw new InvalidOperationException("Güncellemeye çalıştığınız müşteri bulunamadı");
            }
            customer.Name = Model.Name != default ? Model.Name : customer.Name;
            customer.Surname = Model.Surname != default ? Model.Surname : customer.Surname;
            _context.SaveChanges();
        }
    }

    public class UpdateCustomerViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}