using FluentValidation;

namespace SCMS.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.CustomerName)
                .NotEmpty()
                .WithMessage("Customer name is required.");

            RuleFor(x => x.Items)
                .NotEmpty()
                .WithMessage("Order must contain at least one item.");
        }
    }
}
