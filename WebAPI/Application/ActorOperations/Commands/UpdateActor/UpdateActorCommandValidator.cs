using FluentValidation;
using WebAPI.Application.ActorOperations.Commands.UpdateActor;

namespace WebAPI.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommand>
    {
        public UpdateActorCommandValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Model.Surname).NotEmpty().MinimumLength(2);
            RuleFor(x => x.ActorId).NotEmpty().NotNull();
        }
    }
}