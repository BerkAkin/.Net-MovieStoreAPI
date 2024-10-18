using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.OrderOperations.Commands.CreateOrder;
using WebAPI.Application.OrderOperations.Commands.DeleteOrder;
using WebAPI.Application.OrderOperations.Commands.SetOrderAtatusActive;
using WebAPI.Application.OrderOperations.Commands.UpdateOrder;
using WebAPI.Application.OrderOperations.Queries.GetInactiveOrders;
using WebAPI.Application.OrderOperations.Queries.GetOrders;
using WebAPI.DBOperations;

namespace WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]


    public class OrderController : ControllerBase
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public OrderController(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            GetOrdersQuery query = new GetOrdersQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("Inactive")]
        public IActionResult GetInactiveOrders()
        {
            GetInactiveOrdersQuery query = new GetInactiveOrdersQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }


        [HttpGet("{CustomerId}")]
        public IActionResult GetMovieDetail(int CustomerId)
        {
            GetOrderDetailQuery query = new GetOrderDetailQuery(_context, _mapper);
            query.CustomerId = CustomerId;
            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddOrder([FromBody] CreateOrderViewModel order)
        {
            CreateOrderCommand command = new CreateOrderCommand(_context, _mapper);
            CreateOrderCommandValidator validator = new CreateOrderCommandValidator();
            command.Model = order;
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok("Sipariş Oluşturma Başarılı !");
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            DeleteOrderCommand command = new DeleteOrderCommand(_context, _mapper);
            DeleteOrderCommandValidator validator = new DeleteOrderCommandValidator();
            command.OrderId = id;
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok("Silme başarılı");
        }


        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, UpdateOrderViewModel model)
        {
            UpdateOrderCommand command = new UpdateOrderCommand(_context, _mapper);
            UpdateOrderCommandValidator validator = new UpdateOrderCommandValidator();
            command.Model = model;
            command.OrderId = id;
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok("Güncelleme Başarılı");
        }

        [HttpPut("{id}/ChangeStatus")]
        public IActionResult UpdateOrderGenre(int id)
        {
            SetOrderStatusActiveCommand command = new SetOrderStatusActiveCommand(_context, _mapper);
            SetOrderAtatusActiveCommandValidator validator = new SetOrderAtatusActiveCommandValidator();
            command.OrderId = id;
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok("Durum Değişimi Başarılı");
        }

    }
}
