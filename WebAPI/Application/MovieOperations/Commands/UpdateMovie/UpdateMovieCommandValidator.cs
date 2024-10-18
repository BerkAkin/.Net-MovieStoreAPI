using System;
using FluentValidation;

namespace WebAPI.Application.MovieOperations.Commands.UpdateMovie
{

    public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
            RuleFor(x => x.Model.Actors).NotEmpty().NotNull();
            RuleFor(x => x.Model.Genres).NotEmpty().NotNull();
            RuleFor(x => x.Model.Price).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x => x.Model.Year).NotEmpty().NotNull().LessThan(DateTime.Now);
            RuleFor(x => x.Model.Title).NotEmpty().NotNull().MinimumLength(1);
            RuleFor(x => x.Model.ProducerId).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}