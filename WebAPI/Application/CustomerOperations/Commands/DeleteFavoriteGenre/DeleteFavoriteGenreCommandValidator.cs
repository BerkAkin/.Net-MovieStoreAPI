using FluentValidation;
using WebAPI.Application.CustomerOperations.Commands.DeleteFavoriteGenre;

namespace WebAPI.Application.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteFavoriteGenreCommandValidator : AbstractValidator<DeleteFavoriteGenreCommand>
    {
        public DeleteFavoriteGenreCommandValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty().NotNull();
            RuleFor(x => x.Model.Genres).NotNull().NotEmpty();
        }
    }
}