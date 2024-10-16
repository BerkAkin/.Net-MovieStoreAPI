using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebAPI.DBOperations;
using WebAPI.Entites;

namespace WebAPI.Application.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommand
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateActorViewModel Model { get; set; }
        public CreateActorCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var actor = _context.Actors.SingleOrDefault(m => m.Name.ToLower() == Model.Name.ToLower() && m.Surname.ToLower() == Model.Surname.ToLower());
            if (actor is not null)
            {
                throw new InvalidOperationException("Oyuncu zaten mevcut");
            }
            if (Model.IsProducer)
            {
                var producer = _context.Producers.SingleOrDefault(m => m.Name.ToLower() == Model.Name.ToLower() && m.Surname.ToLower() == Model.Surname.ToLower());
                if (producer is not null)
                {
                    throw new InvalidOperationException("Eklemeye çalışılan yapımcı zaten var");
                }
                var newProducer = _mapper.Map<Producer>(Model);
                _context.Producers.Add(newProducer);
            }
            actor = _mapper.Map<Actor>(Model);
            _context.Actors.Add(actor);
            _context.SaveChanges();
        }
    }
    public class CreateActorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsProducer { get; set; }
    }
}