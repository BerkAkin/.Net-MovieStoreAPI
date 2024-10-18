using FluentValidation;

namespace WebAPI.Application.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.Model.Email).NotEmpty().NotNull().MinimumLength(5).EmailAddress();
            RuleFor(x => x.Model.Password).NotNull().NotEmpty().MinimumLength(8);
            RuleFor(x => x.Model.Name).NotNull().NotEmpty().MinimumLength(2);
            RuleFor(x => x.Model.Surname).NotNull().NotEmpty().MinimumLength(2);
        }
    }
}