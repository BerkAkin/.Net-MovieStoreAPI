using System;
using FluentValidation;

namespace WebAPI.Application.MovieOperations.Commands.CreateMovie
{

    public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidator()
        {
            RuleFor(x => x.Model.Actors).NotEmpty().NotNull();
            RuleFor(x => x.Model.Genres).NotEmpty().NotNull();
            RuleFor(x => x.Model.Price).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x => x.Model.Year).NotEmpty().NotNull().LessThan(DateTime.Now.Date);
            RuleFor(x => x.Model.Title).NotEmpty().NotNull().MinimumLength(1);
            RuleFor(x => x.Model.ProducerId).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}