using FluentValidation;
using IsotopeOrdering.App.Models.Shared;
using System.Linq;
namespace IsotopeOrdering.App.Models.Details {
    public class FormDetailModelValidator : AbstractValidator<FormDetailModel> {
        public FormDetailModelValidator() {
            RuleFor(x => x.InitiationModel!).SetValidator(new FormInitiationDetailModelValidator());
        }
    }

    public class FormInitiationDetailModelValidator : AbstractValidator<FormInitiationDetailModel> {
        public FormInitiationDetailModelValidator() {
            RuleFor(x => x.CustomerAdminSignature.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.CustomerAdminSignature.PhoneNumber).NotEmpty().Must(PropertyValidators.BeValidPhoneNumber);
            RuleFor(x => x.Institution).SetValidator(new InstitutionDetailModelValidator());
            RuleFor(x => x.ShippingAddress).SetValidator(new AddressDetailModelValidator());
            RuleFor(x => x.Items).Must(x => x.Any(y => y.IsSelected)).WithMessage(ValidationMessages.NoSelectedItems);
        }
    }
}
