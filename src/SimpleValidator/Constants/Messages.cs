using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleValidator.Constants
{
    /// <summary>
    /// These messages have been taken from 
    /// https://github.com/Microsoft/referencesource/blob/master/System.ComponentModel.DataAnnotations/System.ComponentModel.DataAnnotations.txt
    /// with some alterations
    /// </summary>
    public class Messages
    {
     
        public const string NotEmptyMessage = "'{0}' is empty.";
        public const string NotNullMessage = "'{0}' is null.";
        public const string NotZeroMessage = "'{0}' is zero.";
        public const string IsEmailMessage = "'{0}' is an invalid email address.";
        public const string IsPasswordMessage = "'{0}' is an invalid password. The password must be at least 8 characters, at least 1 uppercase character, at least 1 lowercase character, at least one number and a maximum of 15 characters.";
        public const string IsMatchMessage = "'{0}' does not match.";
        public const string IsLengthMinMessage = "'{0}' must be at least {1} characters.";
        public const string IsLengthMinMaxMessage = "'{0}' must be between {1} and {2} characters.";
        public const string IsExactMessage = "'{0}' must be exactly {1} characters.";
        public const string MustMessage = "'{0}' is invalid."; // generic ?
        public const string MustNotMessage = "'{0}' is invalid."; // generic ?
    }
}
