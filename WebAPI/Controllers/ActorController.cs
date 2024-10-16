using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.ActorOperations.Commands.CreateActor;
using WebAPI.Application.ActorOperations.Commands.DeleteActor;
using WebAPI.Application.ActorOperations.Commands.UpdateActor;
using WebAPI.Application.ActorOperations.Queries.GetActorDetail;
using WebAPI.Application.ActorOperations.Queries.GetActors;
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
        public IActionResult GetActors()
        {
            GetActorsQuery query = new GetActorsQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetActors(int id)
        {
            GetActorDetailQuery query = new GetActorDetailQuery(_context, _mapper);
            query.Id = id;
            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateActor([FromBody] CreateActorViewModel model)
        {
            CreateActorCommand command = new CreateActorCommand(_context, _mapper);
            command.Model = model;
            command.Handle();
            return Ok("Aktör Oluşturma Başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteActor(int id)
        {
            DeleteActorCommand command = new DeleteActorCommand(_context, _mapper);
            command.Id = id;
            command.Handle();
            return Ok("Silme başarılı");
        }


        [HttpPut("{id}")]
        public IActionResult UpdateActor(int id, UpdateActorViewModel model)
        {
            UpdateActorCommand command = new UpdateActorCommand(_context, _mapper);
            command.Model = model;
            command.ActorId = id;
            command.Handle();
            return Ok("Güncelleme Başarılı");
        }




    }
}
