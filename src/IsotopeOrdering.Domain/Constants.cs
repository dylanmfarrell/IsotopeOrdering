using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace IsotopeOrdering.Domain {
    public static class Events {
        public static Dictionary<string, string> GetEvents() {
            Type[] subtypes = typeof(Events).Assembly.GetTypes().Where(type => type == typeof(Customer)
            || type == typeof(Order)
            || type == typeof(Shipment)).ToArray();
            FieldInfo[] infos = subtypes.SelectMany(x => x.GetFields()).ToArray();
            return new Dictionary<string, string>(infos.Select(x => new KeyValuePair<string, string>(x.DeclaringType!.Name + x.Name, x.GetValue(x)!.ToString()!)));
        }

        public static class Customer {
            public const string Created = "Customer created";
            public const string Edited = "Customer edited";
            public const string SubmittedInitiationForm = "Customer has submitted initiation form";
            public const string FormStatusChanged = "Form status changed";
        }

        public static class Order {
            public const string Created = "Order created";
            public const string Edited = "Order edited";
            public const string Sent = "Order sent";
            public const string Approved = "Order approved";
            public const string Denied = "Order denied";
            public const string InProcess = "Order in process";
            public const string Amended = "Order amended";
            public const string ApprovedAmendedOrder = "Approved amended order";
            public const string Complete = "Order completed";
            public const string Cancelled = "Order cancelled";
        }

        public static class Shipment {
            public const string Created = "Shipment created";
            public const string Edited = "Shipment edited";
            public const string Cancelled = "Shipment cancelled";
            public const string Shipped = "Shipment shipped";
        }
    }
}
