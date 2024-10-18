using FluentValidation;

namespace WebAPI.Application.OrderOperations.Commands.SetOrderAtatusActive
{
    public class SetOrderAtatusActiveCommandValidator : AbstractValidator<SetOrderStatusActiveCommand>
    {
        public SetOrderAtatusActiveCommandValidator()
        {
            RuleFor(x => x.OrderId).NotNull().NotEmpty();
        }
    }
}