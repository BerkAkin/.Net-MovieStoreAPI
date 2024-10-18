using FluentValidation;

namespace WebAPI.Application.ProducerOperations.Commands.CreateProducer
{
    public class CreateProducerCommandValidator : AbstractValidator<CreateProducerCommand>
    {
        public CreateProducerCommandValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().NotNull().MinimumLength(2);
            RuleFor(x => x.Model.Surname).NotEmpty().NotNull().MinimumLength(2);
            RuleFor(x => x.Model.IsActor).NotEmpty().NotNull();
        }
    }
}