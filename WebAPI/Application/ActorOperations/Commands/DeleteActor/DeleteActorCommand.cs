using System;
using System.Linq;
using AutoMapper;
using WebAPI.DBOperations;

namespace WebAPI.Application.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommand
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }
        public DeleteActorCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var actor = _context.Actors.SingleOrDefault(x => x.Id == Id);
            if (actor is null)
            {
                throw new InvalidOperationException("Silinecek oyuncu bulunamadı");
            }
            else
            {
                _context.Actors.Remove(actor);

                var producer = _context.Producers.SingleOrDefault(a => a.Name.ToLower() == actor.Name.ToLower() && a.Surname.ToLower() == actor.Surname.ToLower());
                if (producer is not null)
                {
                    producer.IsActor = false;
                }


                _context.SaveChanges();
            }
        }
    }
}