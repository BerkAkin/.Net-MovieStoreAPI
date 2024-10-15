using System.Collections.Generic;
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
            var actor = _mapper.Map<Actor>(Model);
            _context.Actors.Add(actor);
            _context.SaveChanges();
        }
    }
    public class CreateActorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}