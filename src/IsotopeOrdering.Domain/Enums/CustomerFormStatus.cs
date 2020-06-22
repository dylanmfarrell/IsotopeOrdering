namespace IsotopeOrdering.Domain.Enums {
    public enum CustomerFormStatus {
        New = 0,
        AwaitingCustomerSupervisorApproval = 1,
        AwaitingAdminApproval = 2,
        Approved = 3,
        Denied = 4
    }
}
