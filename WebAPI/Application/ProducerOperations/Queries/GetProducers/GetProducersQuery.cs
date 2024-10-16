using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.DBOperations;
using WebAPI.Entites;

namespace WebAPI.Application.ProducerOperations.Queries.GetProducers
{
    public class GetProducersQuery
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetProducersQuery(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetProducerViewModel> Handle()
        {
            List<Producer> producers = _context.Producers.Include(m => m.Movies).ToList();
            if (producers is null)
            {
                throw new InvalidOperationException("Yapımcı Yok");
            }
            List<GetProducerViewModel> vm = _mapper.Map<List<GetProducerViewModel>>(producers);
            return vm;
        }
    }
    public class GetProducerViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<string> Movies { get; set; }
    }
}