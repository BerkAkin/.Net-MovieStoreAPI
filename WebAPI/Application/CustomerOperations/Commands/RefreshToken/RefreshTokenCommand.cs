using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using WebApi.TokenOperations.Models;
using WebAPI.DBOperations;

namespace WebApi.Application.UserOperations.Commands.RefreshToken
{
    public class RefreshTokenCommand
    {
        private readonly MovieStoreDbContext _context;
        private readonly IConfiguration _configuration;

        public string RefreshToken { get; set; }
        public RefreshTokenCommand(MovieStoreDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var user = _context.Customers.FirstOrDefault(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate > DateTime.Now);
            if (user is not null)
            {
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(user);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.ExpirationDate.AddMinutes(5);
                _context.SaveChanges();
                return token;
            }
            else
            {
                throw new InvalidOperationException("Doğru bir refresh token bulunamadı");
            }
        }
    }
}