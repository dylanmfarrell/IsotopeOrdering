using FluentValidation;

namespace IsotopeOrdering.App.Models.Details {
    public class ItemDetailModelValidator : AbstractValidator<ItemDetailModel> {
        public ItemDetailModelValidator() {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Target).NotEmpty();
            RuleFor(x => x.Reaction).NotEmpty();
            RuleFor(x => x.FinalComposition).NotEmpty();
            RuleFor(x => x.DefaultMinQuantity).LessThanOrEqualTo(x => x.DefaultMaxQuantity).WithMessage(ValidationMessages.MinQuantityGreaterThanMax);
            RuleFor(x => x.DefaultMaxQuantity).GreaterThanOrEqualTo(x => x.DefaultMinQuantity).WithMessage(ValidationMessages.MaxQuantityLessThanMin);
        }
    }
}
