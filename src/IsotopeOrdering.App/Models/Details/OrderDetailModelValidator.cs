using FluentValidation;
using IsotopeOrdering.App.Models.Shared;
using System;

namespace IsotopeOrdering.App.Models.Details {
    public class OrderDetailModelValidator : AbstractValidator<OrderDetailModel> {
        public OrderDetailModelValidator() {
            RuleFor(x => x.BillingAddress).SetValidator(new AddressDetailModelValidator());
            RuleFor(x => x.ShippingAddress).SetValidator(new AddressDetailModelValidator());
            RuleFor(x => x.FedExNumber).NotEmpty();
            RuleFor(x => x.Cart).NotEmpty().WithMessage(ValidationMessages.NoSelectedItems);
            RuleForEach(x => x.Cart).SetValidator(new OrderItemDetailModelValidator());
        }
    }

    public class OrderItemDetailModelValidator : AbstractValidator<OrderItemDetailModel> {
        public OrderItemDetailModelValidator() {
            RuleFor(x => x.Quantity).GreaterThan(0);
            RuleFor(x => x.RequestedDate).GreaterThan(DateTime.Now).WithMessage(ValidationMessages.RequestedDateGreaterThanToday);
        }
    }
}
