using System;
using System.Linq;
using AutoMapper;
using WebAPI.DBOperations;

namespace WebAPI.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommand
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int ActorId { get; set; }
        public UpdateActorViewModel Model { get; set; }
        public UpdateActorCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var actor = _context.Actors.SingleOrDefault(g => g.Id == ActorId);
            if (actor is null)
            {
                throw new InvalidOperationException("Güncellenecek oyuncu bulunamadı");
            }
            actor.Name = Model.Name != default ? Model.Name : actor.Name;
            actor.Surname = Model.Surname != default ? Model.Surname : actor.Surname;
            _context.SaveChanges();
        }
    }

    public class UpdateActorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}