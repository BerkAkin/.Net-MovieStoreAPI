using System;
using System.Linq;
using AutoMapper;
using WebAPI.DBOperations;

namespace WebAPI.Application.ProdcuerOperations.Commands.DeleteProducer
{
    public class DeleteProducerCommand
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }
        public DeleteProducerCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var producer = _context.Producers.SingleOrDefault(p => p.Id == Id);
            if (producer is null)
            {
                throw new InvalidOperationException("Yapımcı bulunamadı");

            }

            var actor = _context.Actors.SingleOrDefault(a => a.Name.ToLower() == producer.Name.ToLower() && a.Surname.ToLower() == producer.Surname.ToLower());
            if (actor is not null)
            {
                actor.IsProducer = false;
            }


            _context.Producers.Remove(producer);
            _context.SaveChanges();
        }
    }
}