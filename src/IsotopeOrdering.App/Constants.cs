namespace IsotopeOrdering.App {
    public static class Events {
        public const string CustomerCreated = "Customer created with id {id}";
        public const string ObtainedInitiationForm = "Customer has obtained initiation form";
        public const string SubmittedInitiationForm = "Customer has submitted initiation form";
        public const string ResubmittedInitiationForm = "Customer has resubmitted initiation form {customerformid}";
        public const string ValidationFailedInitiationForm = "Customer has submitted an invalid initiation form";
        public const string SubmissionSuccessInitiationForm = "Customer has submitted a valid initiation form";
        public const string FormStatusChanged = "Form {customerFormId} status changed to {status}";

        public const string ObtainedOrderForm = "Customer has obtained order form";

    }

    public static class ValidationMessages {
        public const string NoShippingAddress = "Must have at least one shipping address";
        public const string NoBillingAddress = "Must have at least one shipping address";
        public const string NoSelectedItems = "Must have at least one item selected";
        public const string MinQuantityGreaterThanMax = "Minimum quantity must be greater than or equal to maximum quantity";
        public const string MaxQuantityLessThanMin = "Maximum quantity must be less than or equal to minimum quantity";
    }
}
