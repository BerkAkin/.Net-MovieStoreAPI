using FluentValidation;

namespace WebAPI.Application.CustomerOperations.Commands.AddFavoriteGenre
{
    public class AddFavoriteGenreCommandValidator : AbstractValidator<AddFavoriteGenreCommand>
    {
        public AddFavoriteGenreCommandValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty().NotNull();
            RuleFor(x => x.Model.Genres).NotNull().NotEmpty();
        }
    }
}