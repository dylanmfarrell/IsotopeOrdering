namespace IsotopeOrdering.Domain.Enums {
    public enum CustomerStatus {
        /// <summary>
        /// Customer has been created and not assigned a MTA
        /// </summary>
        New = 0,
        /// <summary>
        /// Customer has submitted their MTA and is awaiting approval
        /// </summary>
        Pending = 1,
        /// <summary>
        /// Customer's MTA has been reviewed and accepted
        /// </summary>
        Initiated = 2
    }
}
