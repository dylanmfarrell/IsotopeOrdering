using FluentValidation;
using IsotopeOrdering.App.Models.Shared;
using System;

namespace IsotopeOrdering.App.Models.Details {
    public class OrderDetailModelValidator : AbstractValidator<OrderDetailModel> {
        public OrderDetailModelValidator() {
            RuleFor(x => x.BillingAddress).SetValidator(new AddressDetailModelValidator());
            RuleFor(x => x.ShippingAddress).SetValidator(new AddressDetailModelValidator());
            RuleFor(x => x.BillingContact).SetValidator(new ContactDetailModelValidator());
            RuleFor(x => x.Cart).NotEmpty().WithMessage(ValidationMessages.NoSelectedItems);
            RuleForEach(x => x.Cart).SetValidator(new OrderItemDetailModelValidator());
        }
    }

    public class OrderItemDetailModelValidator : AbstractValidator<OrderItemDetailModel> {
        public OrderItemDetailModelValidator() {
            RuleFor(x => x.Quantity).GreaterThan(0);
            RuleFor(x => x.RequestedDate).Custom((x, context) => {
                if (x.HasValue) {
                    if (x < DateTime.Now.AddDays(2)) {
                        context.AddFailure(ValidationMessages.RequestedDateGreaterThanToday);
                    }
                    if (x.Value.DayOfWeek == DayOfWeek.Saturday || x.Value.DayOfWeek == DayOfWeek.Sunday) {
                        context.AddFailure(ValidationMessages.RequestedDateNotOnWeekend);
                    }
                    else if (x.Value.DayOfWeek == DayOfWeek.Monday) {
                        context.AddFailure(ValidationMessages.RequestedDateNotOnMonday);
                    }
                }
            });
        }
    }
}
