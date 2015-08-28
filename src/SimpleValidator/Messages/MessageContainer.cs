using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleValidator.Messages
{
    public class MessageContainer
    {
        public string IsNotNullMessage { get; set; }
        public string IsNotNullOrEmptyMessage { get; set; }
        public string IsNotNullOrWhiteSpaceMessage { get; set; }
        public string IsNotZeroMessage { get; set; }
        public string IsPasswordMessage { get; set; }
        public string IsMinLengthMessage { get; set; }
        public string IsMaxLengthMessage { get; set; }
        public string IsExactLengthMessage { get; set; }
        public string IsBetweenLengthMessage { get; set; }
        public string IsMessage { get; set; }
        public string IsNotMessage { get; set; }
        public string IsEmailMessage { get; set; }
        public string IsRegexMessage { get; set; }
        public string IsMatchMessage { get; set; }
        public string IsDateMessage { get; set; }
        public string IsRuleMessage { get; set; }
    }
}
