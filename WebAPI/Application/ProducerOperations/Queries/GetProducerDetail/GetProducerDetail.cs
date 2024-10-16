using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.DBOperations;
using WebAPI.Entites;

namespace WebAPI.Application.ProducerOperations.Queries.GetProducerDetail
{
    public class GetProducerDetailQuery
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }
        public GetProducerDetailQuery(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetProducerDetailViewModel Handle()
        {
            var producer = _context.Producers.Include(m => m.Movies).SingleOrDefault(p => p.Id == Id);
            if (producer is null)
            {
                throw new InvalidOperationException("Yapımcı bulunamadı");

            }
            GetProducerDetailViewModel vm = _mapper.Map<GetProducerDetailViewModel>(producer);
            return vm;
        }
    }

    public class GetProducerDetailViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<string> Movies { get; set; }
    }
}