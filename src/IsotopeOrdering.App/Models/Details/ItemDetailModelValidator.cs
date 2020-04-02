using FluentValidation;

namespace IsotopeOrdering.App.Models.Details {
    public class ItemDetailModelValidator : AbstractValidator<ItemDetailModel> {
        public ItemDetailModelValidator() {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Target).NotEmpty();
            RuleFor(x => x.Reaction).NotEmpty();
            RuleFor(x => x.FinalComposition).NotEmpty();
            RuleFor(x => x.SpecificActivity).NotEmpty();
            RuleFor(x => x.QualityControlAnalysis).NotEmpty();
            RuleFor(x => x.MinQuantity).LessThan(x => x.MaxQuantity);
        }
    }
}
