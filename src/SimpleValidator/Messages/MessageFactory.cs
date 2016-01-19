using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleValidator.Messages
{
    public class MessageFactory
    {
        private MessageFactory()
        {
        }

        /// <summary>
        /// Provides the default language instance of the messages
        /// </summary>
        /// <returns></returns>
        public static MessageContainer Create()
        {
            return Create(LanguageCodes.en_GB);
        }

        public static MessageContainer Create(LanguageCodes code)
        {
            switch (code)
            {
                case LanguageCodes.en_GB:
                    return new MessageContainer()
                    {
                        IsNotNullMessage = "'{0}' cannot be null.",
                        IsNotNullOrEmptyMessage = "'{0}' cannot be null or empty.",
                        IsNotNullOrWhiteSpaceMessage = "'{0}' cannot be null or whitespace only.",
                        IsNotZeroMessage = "'{0}' cannot be zero.",
                        IsPasswordMessage = "'{0}' is not a valid password. Passwords must be 8 to 30 characters, at least on 1 uppercase letter, at least 1 lowercase letter and at least one number.",
                        IsMinLengthMessage = "'{0}' must be a at least {1} characters.",
                        IsMaxLengthMessage = "'{0}' must be {1} characters or less.",
                        IsExactLengthMessage = "'{0}' must be exactly {1} characters.",
                        IsBetweenLengthMessage = "'{0}' must be at least {1} and at most {2} characters.",
                        IsMessage = "'{0}' does not match the specified criteria.",
                        IsNotMessage = "'{0}' does not match the specified criteria.",
                        IsEmailMessage = "'{0}' is not a valid email address.",
                        IsRegexMessage = "'{0}' does not match the provided regular expression.",
                        IsMatchMessage = "'{0}' did not match the specified criteria.",
                        IsDateMessage = "'{0}' is not a valid date.",
                        IsRuleMessage = "'{0}' failed the provided business rule provided.",

                        // Dates
                        IsGreaterThanMessage = "'{0}' must be greater than '{1}'.",
                        IsGreaterThanOrEqualToMessage =  "'{0}' must be greater than or equal to '{1}'.",
                        IsLessThanMessage =  "'{0}' must be less than '{1}'.",
                        IsLessThanOrEqualToMessage = "'{0}' must be less than or equal to '{1}'.",
                        IsEqualToMessage = "'{0}' must be equal to '{1}'.",
                        IsBetweenInclusiveMessage = "'{0}' must be between '{1}' and '{2}' (inclusive).",
                        IsBetweenExclusiveMessage = "'{0}' must be between '{1}' and '{2}' (exclusive)."
                    };

                default:
                    return Create(LanguageCodes.en_GB);
            }


        }
    }
}
