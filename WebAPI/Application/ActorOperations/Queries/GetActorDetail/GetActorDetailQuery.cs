using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.DBOperations;


namespace WebAPI.Application.ActorOperations.Queries.GetActorDetail
{
    public class GetActorDetailQuery
    {
        private readonly IMapper _mapper;
        private readonly MovieStoreDbContext _context;
        public int Id { get; set; }
        public GetActorDetailQuery(MovieStoreDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public GetActorDetailViewModel Handle()
        {
            var actor = _context.Actors.Include(m => m.Movies).SingleOrDefault(a => a.Id == Id);
            if (actor is null)
            {
                throw new InvalidOperationException("Aktör bulunamadı");
            }
            GetActorDetailViewModel vm = _mapper.Map<GetActorDetailViewModel>(actor);
            return vm;
        }
    }
    public class GetActorDetailViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<string> Movies { get; set; }
    }
}