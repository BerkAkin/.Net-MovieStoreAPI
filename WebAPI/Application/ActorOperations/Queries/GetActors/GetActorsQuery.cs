using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.DBOperations;
using WebAPI.Entites;

namespace WebAPI.Application.ActorOperations.Queries.GetActors
{
    public class GetActorsQuery
    {
        private readonly IMapper _mapper;
        private readonly MovieStoreDbContext _context;
        public GetActorsQuery(MovieStoreDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public List<GetActorsViewModel> Handle()
        {
            var actors = _context.Actors.Include(m => m.Movies).ToList();
            if (actors is null)
            {
                throw new InvalidOperationException("Aktörler bulunamadı");
            }
            List<GetActorsViewModel> actorList = _mapper.Map<List<GetActorsViewModel>>(actors);
            return actorList;
        }
    }
    public class GetActorsViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<string> Movies { get; set; }
    }
}