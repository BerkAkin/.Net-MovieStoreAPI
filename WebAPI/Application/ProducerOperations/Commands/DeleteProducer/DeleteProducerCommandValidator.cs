using FluentValidation;

namespace WebAPI.Application.ProducerOperations.Commands.DeleteProducer
{
    public class DeleteProducerCommandValidator : AbstractValidator<DeleteProducerCommand>
    {
        public DeleteProducerCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}