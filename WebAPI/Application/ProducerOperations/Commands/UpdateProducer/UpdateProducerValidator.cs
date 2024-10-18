using FluentValidation;

namespace WebAPI.Application.ProducerOperations.Commands.UpdateProducer
{
    public class UpdateProducerCommandValidator : AbstractValidator<UpdateProducerCommand>
    {
        public UpdateProducerCommandValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().NotNull().MinimumLength(2);
            RuleFor(x => x.Model.Surname).NotEmpty().NotNull().MinimumLength(2);
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}