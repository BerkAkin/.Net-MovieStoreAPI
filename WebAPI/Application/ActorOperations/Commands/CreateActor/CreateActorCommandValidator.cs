using FluentValidation;

namespace WebAPI.Application.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommandValidator : AbstractValidator<CreateActorCommand>
    {
        public CreateActorCommandValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Model.Surname).NotEmpty().MinimumLength(2);
        }
    }
}