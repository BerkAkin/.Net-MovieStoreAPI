using FluentValidation;

namespace WebAPI.Application.MovieOperations.Commands.DeleteMovie
{

    public class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand>
    {
        public DeleteMovieCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}