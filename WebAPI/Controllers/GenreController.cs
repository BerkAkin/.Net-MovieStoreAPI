using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.GenreOperations.Commands.CreateGenre;
using WebAPI.Application.GenreOperations.Commands.DeleteGenre;
using WebAPI.Application.GenreOperations.Commands.UpdateGenre;
using WebAPI.Application.GenreOperations.Queries.GetGenreDetail;
using WebAPI.Application.GenreOperations.Queries.GetGenres;
using WebAPI.DBOperations;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]s")]


    public class GenreController : ControllerBase
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GenreController(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGenres()
        {
            GetGenresQuery query = new GetGenresQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetGenreDetail(int id)
        {
            GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);
            query.GenreId = id;
            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateGenre([FromBody] CreateGenreViewModel model)
        {
            CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            command.Model = model;
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok("Genre oluşturma başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context, _mapper);
            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            command.GenreId = id;
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok("Silme başarılı");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id, UpdateGenreViewModel model)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context, _mapper);
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            command.Model = model;
            command.GenreId = id;
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok("Güncelleme Başarılı");
        }

    }
}
