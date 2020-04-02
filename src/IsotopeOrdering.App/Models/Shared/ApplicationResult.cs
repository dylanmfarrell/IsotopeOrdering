using FluentValidation.Results;
using System;

namespace IsotopeOrdering.App.Models.Shared {
    public class ApplicationResult {
        public ApplicationResult(string message, bool isSuccessful) {
            Message = message;
            IsSuccessful = isSuccessful;
            Data = null;
        }
        public string Message { get; set; }
        public bool IsSuccessful { get; set; }
        public object? Data { get; set; }

        public static ApplicationResult Error(Exception ex) {
            return new ApplicationResult(ex.Message, false);
        }

        public static ApplicationResult Error(ValidationResult result) {
            return new ApplicationResult(string.Join(", ", result.Errors), false) { Data = result.Errors };
        }

        public static ApplicationResult Error(string message) {
            return new ApplicationResult(message, false) { };
        }

        public static ApplicationResult Success(string message, object data) {
            return new ApplicationResult(message, true) { Data = data };
        }
    }
}
