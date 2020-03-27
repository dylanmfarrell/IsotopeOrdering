﻿using FluentValidation.Results;
using System;
using System.Collections.Generic;

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

        public static ApplicationResult Error(IEnumerable<ValidationFailure> failures) {
            return new ApplicationResult(string.Join(", ", failures), false) { Data = failures };
        }

        public static ApplicationResult Error(string message) {
            return new ApplicationResult(message, false) { };
        }

        public static ApplicationResult Success(string message, object data) {
            return new ApplicationResult(message, true) { Data = data };
        }
    }
}
