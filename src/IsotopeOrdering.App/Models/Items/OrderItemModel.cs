﻿using IsotopeOrdering.Domain.Enums;
using MIR.Core.Domain;

namespace IsotopeOrdering.App.Models.Items {
    public class OrderItemModel : ModelBase {
        public CustomerItemModel Customer { get; set; } = new CustomerItemModel();
        public InstitutionItemModel Institution { get; set; } = new InstitutionItemModel();
        public OrderStatus Status { get; set; }
        public bool ReadyToReview => Status == OrderStatus.Sent;
        public bool ReadyToProcess => Status == OrderStatus.Approved;
        public bool ReadyToComplete => Status == OrderStatus.InProcess;
    }
}
