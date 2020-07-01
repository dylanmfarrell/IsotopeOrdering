using IsotopeOrdering.App.Models.Details;

namespace IsotopeOrdering.App.Models.Notifications {
    public class ExternalMtaNotification {
        public ExternalMtaNotification(string baseUrl, FormDetailModel form) {
            Form = form;
            FormUrl = baseUrl + $"/Form/{form.InitiationModel!.CustomerAdminSignature.Email}/{form.FormIdentifier}";
        }

        public FormDetailModel Form { get; set; }
        public string FormUrl { get; private set; }
    }
}
