using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApi.Application.UserOperations.Commands;
using WebApi.Application.UserOperations.Commands.RefreshToken;
using WebApi.TokenOperations.Models;
using WebAPI.Application.CustomerOperations.Commands.AddFavoriteGenre;
using WebAPI.Application.CustomerOperations.Commands.CreateCustomer;
using WebAPI.Application.CustomerOperations.Commands.DeleteCustomer;
using WebAPI.Application.CustomerOperations.Commands.DeleteFavoriteGenre;
using WebAPI.Application.CustomerOperations.Commands.UpdateCustomer;
using WebAPI.Application.CustomerOperations.Queries.GetCustomerDetail;
using WebAPI.Application.CustomerOperations.Queries.GetCustomers;
using WebAPI.DBOperations;

namespace WebAPI.Controllers
{

    [ApiController]
    [Route("[controller]s")]


    public class CustomerController : ControllerBase
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CustomerController(MovieStoreDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            GetCustomersQuery query = new GetCustomersQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetCustomerDetail(int id)
        {
            GetCustomerDetailQuery query = new GetCustomerDetailQuery(_context, _mapper);
            query.Id = id;
            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CreateCustomerViewModel model)
        {
            CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
            command.Model = model;
            command.Handle();
            return Ok("Müşteri oluşturma başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            DeleteCustomerCommand command = new DeleteCustomerCommand(_context, _mapper);
            command.CustomerId = id;
            command.Handle();
            return Ok("Silme başarılı");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] UpdateCustomerViewModel model)
        {
            UpdateCustomerCommand command = new UpdateCustomerCommand(_context, _mapper);
            command.Id = id;
            command.Model = model;
            command.Handle();
            return Ok("Güncelleme başarılı");
        }

        [HttpPut("{id}/FavoriteGenres")]
        public IActionResult AddFavoriteGenreToCustomer(int id, [FromBody] AddFavoriteGenreViewModel model)
        {
            AddFavoriteGenreCommand command = new AddFavoriteGenreCommand(_context, _mapper);
            command.CustomerId = id;
            command.Model = model;
            command.Handle();
            return Ok("Ekleme başarılı");
        }

        [HttpDelete("{id}/FavoriteGenres")]
        public IActionResult DeleteFavoriteGenre(int id, [FromBody] DeleteFavoriteGenreViewModel model)
        {
            DeleteFavoriteGenreCommand command = new DeleteFavoriteGenreCommand(_context, _mapper);
            command.CustomerId = id;
            command.Model = model;
            command.Handle();
            return Ok("Silme başarılı");
        }

        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand command = new CreateTokenCommand(_context, _mapper, _configuration);
            command.Model = login;
            var token = command.Handle();
            return token;
        }

        [HttpGet("refreshToken")]
        public ActionResult<Token> CreateRefreshToken([FromQuery] string token)
        {
            RefreshTokenCommand command = new RefreshTokenCommand(_context, _configuration);
            command.RefreshToken = token;
            var resultToken = command.Handle();
            return resultToken;
        }


    }
}
