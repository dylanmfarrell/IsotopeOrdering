using FluentValidation;
using IsotopeOrdering.App.Models.Shared;

namespace IsotopeOrdering.App.Models.Details {
    public class OrderDetailModelValidator : AbstractValidator<OrderDetailModel> {
        public OrderDetailModelValidator() {
            RuleFor(x => x.BillingAddress).SetValidator(new AddressDetailModelValidator());
            RuleFor(x => x.ShippingAddress).SetValidator(new AddressDetailModelValidator());
            RuleFor(x => x.FedExNumber).NotEmpty();
            RuleFor(x => x.Cart).NotEmpty().WithMessage(ValidationMessages.NoSelectedItems);
        }
    }
}
