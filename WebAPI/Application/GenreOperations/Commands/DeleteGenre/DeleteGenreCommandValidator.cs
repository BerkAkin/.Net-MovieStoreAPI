using FluentValidation;

namespace WebAPI.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(x => x.GenreId).NotEmpty().NotNull();
        }
    }
}