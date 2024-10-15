using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.ActorOperations.Queries.GetActorDetail;
using WebAPI.Application.ActorOperations.Queries.GetActors;
using WebAPI.Application.MovieOperations.Commands.CreateMovie;
using WebAPI.Application.MovieOperations.Commands.DeleteMovie;
using WebAPI.Application.MovieOperations.Commands.UpdateMovie;
using WebAPI.Application.MovieOperations.Queries.GetMovieDetail;
using WebAPI.Application.MovieOperations.Queries.GetMovies;
using WebAPI.DBOperations;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]s")]


    public class ActorController : ControllerBase
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public ActorController(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult getActors()
        {
            GetActorsQuery query = new GetActorsQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult getActors(int id)
        {
            GetActorDetailQuery query = new GetActorDetailQuery(_context, _mapper);
            query.Id = id;
            var result = query.Handle();
            return Ok(result);
        }



    }
}
