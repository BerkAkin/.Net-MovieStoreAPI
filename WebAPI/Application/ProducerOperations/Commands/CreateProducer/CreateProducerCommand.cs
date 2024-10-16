using System;
using System.Linq;
using AutoMapper;
using WebAPI.DBOperations;
using WebAPI.Entites;

namespace WebAPI.Application.ProdcuerOperations.Commands.CreateProducer
{
    public class CreateProducerCommand
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateProducerViewModel Model { get; set; }

        public CreateProducerCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var producer = _context.Producers.SingleOrDefault(m => m.Name.ToLower() == Model.Name.ToLower() && m.Surname.ToLower() == Model.Surname.ToLower());

            if (producer is not null)
            {
                throw new InvalidOperationException("Eklemeye çalıştığınız yapımcı zaten mevcut");
            }
            if (Model.IsActor)
            {
                var actor = _context.Actors.SingleOrDefault(m => m.Name.ToLower() == Model.Name.ToLower() && m.Surname.ToLower() == Model.Surname.ToLower());
                if (actor is not null)
                {
                    throw new InvalidOperationException("Eklemeye çalışılan aktör zaten var");
                }
                var newActor = _mapper.Map<Actor>(Model);
                _context.Actors.Add(newActor);

            }

            Producer vm = _mapper.Map<Producer>(Model);
            _context.Producers.Add(vm);
            _context.SaveChanges();
        }
    }
    public class CreateProducerViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsActor { get; set; }
    }
}