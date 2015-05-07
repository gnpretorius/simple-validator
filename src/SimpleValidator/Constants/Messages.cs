using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleValidator.Constants
{
    public class Messages
    {
        public const string NotEmptyMessage = "'{0}' cannot be null or empty.";
        public const string NotValidEmail = "'{0}' is not a valid email address.";
        public const string NotNullMessage = "'{0}' cannot be null.";
        public const string NotZeroMessage = "'{0}' cannot be zero.";
        public const string IsPasswordMessage = "'{0}' is not a valid password.";
        public const string IsLengthMinMessage = "'{0}' must be a at least {1} characters.";
        public const string IsLengthMinMaxMessage = "'{0}' must be a at least {1} and at most {2} characters.";
        public const string MustMessage = "'{0}' does not match the specified criteria.";
        public const string MustNotMessage = "'{0}' does not match the specified criteria.";
        public const string IsEmailMessage = "'{0}' is not a valid email address.";
        public const string IsMatchMessage = "'{0}' did not match the specified criteria.";
    }
}
