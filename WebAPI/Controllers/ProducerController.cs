using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.ProducerOperations.Commands.CreateProducer;
using WebAPI.Application.ProducerOperations.Commands.DeleteProducer;
using WebAPI.Application.ProducerOperations.Commands.UpdateProducer;
using WebAPI.Application.ProducerOperations.Queries.GetProducerDetail;
using WebAPI.Application.ProducerOperations.Queries.GetProducers;
using WebAPI.DBOperations;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]s")]


    public class ProducerController : ControllerBase
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public ProducerController(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult getProducers()
        {
            GetProducersQuery query = new GetProducersQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult getProducerDetail(int id)
        {
            GetProducerDetailQuery query = new GetProducerDetailQuery(_context, _mapper);
            query.Id = id;
            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateProducer([FromBody] CreateProducerViewModel model)
        {
            CreateProducerCommand command = new CreateProducerCommand(_context, _mapper);
            command.Model = model;
            command.Handle();
            return Ok("Yapımcı oluşturma başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProducer(int id)
        {
            DeleteProducerCommand command = new DeleteProducerCommand(_context, _mapper);
            command.Id = id;
            command.Handle();
            return Ok("Silme başarılı");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProducer(int id, UpdateProducerViewModel model)
        {
            UpdateProducerCommand command = new UpdateProducerCommand(_context, _mapper);
            command.Model = model;
            command.Id = id;
            command.Handle();
            return Ok("Güncelleme Başarılı");
        }




    }
}
