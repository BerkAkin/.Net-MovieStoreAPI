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
                throw new InvalidOperationException("Silinecek Film Bulunamadı");
            }
            else
            {
                _context.Actors.Remove(actor);
                _context.SaveChanges();
            }
        }
    }
}