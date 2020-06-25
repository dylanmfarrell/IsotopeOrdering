namespace IsotopeOrdering.Domain.Enums {
    public enum CustomerStatus {
        /// <summary>
        /// Customer has been created and not assigned a MTA
        /// </summary>
        New = 0,
        /// <summary>
        /// Customer's MTA has been reviewed and accepted
        /// </summary>
        Initiated = 1,
        /// <summary>
        /// Customer cannot order or alter any information
        /// </summary>
        Locked = 2,
    }
}
