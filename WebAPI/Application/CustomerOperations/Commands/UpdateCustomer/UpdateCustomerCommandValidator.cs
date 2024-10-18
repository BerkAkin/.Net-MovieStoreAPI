using FluentValidation;
using WebAPI.Application.CustomerOperations.Commands.DeleteFavoriteGenre;

namespace WebAPI.Application.CustomerOperations.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
            RuleFor(x => x.Model.Name).NotNull().NotEmpty().MinimumLength(2);
            RuleFor(x => x.Model.Surname).NotNull().NotEmpty().MinimumLength(2);
        }
    }
}