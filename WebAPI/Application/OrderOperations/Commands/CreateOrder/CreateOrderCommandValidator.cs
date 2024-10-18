using FluentValidation;

namespace WebAPI.Application.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.Model.CustomerId).NotNull().NotEmpty();
            RuleFor(x => x.Model.MovieId).NotNull().NotEmpty();
            RuleFor(x => x.Model.Price).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.Model.PurchaseDate).NotNull().NotEmpty();

        }
    }
}