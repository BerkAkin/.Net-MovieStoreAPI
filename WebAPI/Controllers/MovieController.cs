using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
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


        [HttpPost]
        public IActionResult AddMovie([FromBody] CreateMovieViewModel movie)
        {
            CreateMovieCommand command = new CreateMovieCommand(_context, _mapper);
            CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
            command.Model = movie;
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok("Film Ekleme Başarılı !");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            DeleteMovieCommand command = new DeleteMovieCommand(_context, _mapper);
            DeleteMovieCommandValidator validator = new DeleteMovieCommandValidator();
            command.Id = id;
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok("Film Silme Başarılı");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieViewModel model)
        {
            UpdateMovieCommand command = new UpdateMovieCommand(_context, _mapper);
            UpdateMovieCommandValidator validator = new UpdateMovieCommandValidator();
            command.Id = id;
            command.Model = model;
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok("Film Güncelleme Başarılı");
        }

    }
}
