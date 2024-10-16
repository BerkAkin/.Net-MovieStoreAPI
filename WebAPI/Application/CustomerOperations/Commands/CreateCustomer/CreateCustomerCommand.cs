using System;
using System.Linq;
using AutoMapper;
using WebAPI.DBOperations;
using WebAPI.Entites;

namespace WebAPI.Application.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommand
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateCustomerViewModel Model { get; set; }
        public CreateCustomerCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public void Handle()
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Name.ToLower() == Model.Name.ToLower() && c.Surname.ToLower() == Model.Surname.ToLower());
            if (customer is not null)
            {
                throw new InvalidOperationException("Eklemeye çalıştığınız müşteri zaten mevcut");
            }
            var newCustomer = _mapper.Map<Customer>(Model);
            _context.Customers.Add(newCustomer);
            _context.SaveChanges();
        }
    }

    public class CreateCustomerViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}