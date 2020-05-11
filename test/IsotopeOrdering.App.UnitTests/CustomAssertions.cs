using FluentValidation.Results;
using IsotopeOrdering.App.Models.Shared;
using System.Collections.Generic;
using Xunit;

namespace IsotopeOrdering.App.UnitTests {
    public static class CustomAssertions {
        public static void AssertExcpetionErrorsExist(ApplicationResult result) {
            Assert.False(result.IsSuccessful);
        }

        public static void AssertValidationErrorsExist(ApplicationResult result) {
            Assert.IsType<List<ValidationFailure>>(result.Data);
            Assert.False(result.IsSuccessful);
        }

        public static void AssertValidationErrorsDoNotExist(ApplicationResult result) {
            Assert.IsNotType<List<ValidationFailure>>(result.Data);
            Assert.True(result.IsSuccessful);
        }
    }
}
