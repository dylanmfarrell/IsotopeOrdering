namespace IsotopeOrdering.App {

    public static class Events {
        public static class Customer {
            public const string Created = "Customer created";
            public const string Edited = "Customer edited";
            public const string ObtainedInitiationForm = "Customer has obtained initiation form";
            public const string SubmittedInitiationForm = "Customer has submitted initiation form";
            public const string ResubmittedInitiationForm = "Customer has resubmitted initiation form";
            public const string ValidationFailedInitiationForm = "Customer has submitted an invalid initiation form";
            public const string SubmissionSuccessInitiationForm = "Customer has submitted a valid initiation form";
            public const string FormStatusChanged = "Form status changed";
            public const string SubmittedOrderForm = "Customer has submitted order form";
        }

        public static class Order {
            public const string Created = "Order created";
            public const string Edited = "Order edited";
            public const string Sent = "Order Sent";
            public const string Approved = "Order Approved";
            public const string Denied = "Order Denied";
            public const string InProcess = "Order In Process";
            public const string Amended = "Order Amended";
            public const string ApprovedAmendedOrder = "Approved amended order";
            public const string Complete = "Order Completed";
            public const string Cancelled = "Order Cancelled";
        }

        public static class Shipment {
            public const string Created = "Shipment created";
            public const string Edited = "Shipment edited";
        }
    }

    public static class ValidationMessages {
        public const string NoShippingAddress = "Must have at least one shipping address";
        public const string NoBillingAddress = "Must have at least one billing address";
        public const string NoSelectedItems = "Must have at least one material selected";
        public const string MinQuantityGreaterThanMax = "Minimum quantity must be greater than or equal to maximum quantity";
        public const string MaxQuantityLessThanMin = "Maximum quantity must be less than or equal to minimum quantity";
        public const string RequestedDateGreaterThanToday = "Requested date must be at least two days after today's date";
        public const string RequestedDateNotOnWeekend = "Requested date cannot be fall on the weekend";
        public const string RequestedDateNotOnMonday = "Requested date cannot be fall on a Monday. Please specify why this needs to occur on a Monday in the special instructions instead.";
    }

    public static class Policies {
        public const string AdminPolicy = "AdminPolicy";
        public const string ReviewerPolicy = "ReviewPolicy";
        public const string CustomerPolicy = "CustomerPolicy";
        public const string OrderPolicy = "OrderPolicy";
    }

    public static class UploadModules {
        public const string CustomerDocument = "CustomerDocument";
        public const string ShipmentDocument = "ShipmentDocument";
    }

    public static class ViewDataKeys {
        public const string Title = "Title";
        public const string ApplicationResult = "ApplicationResult";
        public const string Readonly = "Readonly";
        public const string UploadModule = "UploadModule";
        public const string Customers = "Customers";
        public const string AddressType = "AddressType";
        public const string Action = "Action";
        public const string Info = "Info";
        public const string CurrentAddress = "CurrentAddress";
    }
}
