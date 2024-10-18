using FluentValidation;

namespace WebAPI.Application.OrderOperations.Commands.DeleteOrder
{
    public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator()
        {
            RuleFor(x => x.OrderId).NotNull().NotEmpty();
        }
    }
}