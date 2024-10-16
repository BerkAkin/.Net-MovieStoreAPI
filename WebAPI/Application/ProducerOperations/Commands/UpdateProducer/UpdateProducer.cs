using System.Linq;
using AutoMapper;
using WebAPI.DBOperations;

namespace WebAPI.Application.ProducerOperations.Commands.UpdateProducer
{
    public class UpdateProducerCommand
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }
        public UpdateProducerViewModel Model { get; set; }

        public UpdateProducerCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var producer = _context.Producers.SingleOrDefault(p => p.Id == Id);
            producer.Name = Model.Name != default ? Model.Name : producer.Name;
            producer.Surname = Model.Surname != default ? Model.Surname : producer.Surname;
            _context.SaveChanges();

        }
    }

    public class UpdateProducerViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}