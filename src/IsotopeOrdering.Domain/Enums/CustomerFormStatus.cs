namespace IsotopeOrdering.Domain.Enums {
    public enum CustomerFormStatus {
        Assigned = 0,
        AwaitingSignature = 1,
        SignedBySafetyContact = 2,
        Completed = 3,
        Approved = 4,
        Denied = 5
    }
}
