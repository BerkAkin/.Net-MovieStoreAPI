using FluentValidation;

namespace WebAPI.Application.OrderOperations.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(x => x.Model.CustomerId).NotNull().NotEmpty();
            RuleFor(x => x.Model.MovieId).NotNull().NotEmpty();
            RuleFor(x => x.Model.Price).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.OrderId).NotNull().NotEmpty();
        }
    }
}