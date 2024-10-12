using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.MovieOperations.Queries.GetMovieDetail;
using WebAPI.Application.MovieOperations.Queries.GetMovies;
using WebAPI.DBOperations;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]s")]


    public class MovieController : ControllerBase
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public MovieController(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            GetMoviesQuery query = new GetMoviesQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetMovieDetail(int id)
        {
            GetMovieDetailQuery query = new GetMovieDetailQuery(_context, _mapper);
            query.MovieId = id;
            var result = query.Handle();
            return Ok(result);
        }

    }
}
