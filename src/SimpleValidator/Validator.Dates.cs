using SimpleValidator.Extensions;
using SimpleValidator.Results;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SimpleValidator
{
    public partial class Validator
    {
        #region " IsDate "

        public Validator IsDate(object value)
        {
            return IsDate("", value);
        }

        public Validator IsDate(string name, object value)
        {
            return IsDate(name, value, string.Format(MessageContainer.IsDateMessage, name));
        }

        public Validator IsDate(string name, object value, string message)
        {
            // do the check
            if (value.IsDate())
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        public Validator IsDate(object value, CultureInfo info)
        {
            return IsDate("", value, info);
        }

        public Validator IsDate(string name, object value, CultureInfo info)
        {
            return IsDate(name, value, string.Format(MessageContainer.IsDateMessage, name), info);
        }

        public Validator IsDate(string name, object value, string message, CultureInfo info)
        {
            // do the check
            if (value.IsDate(info))
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        public Validator IsDate(object value, CultureInfo info, DateTimeStyles styles)
        {
            return IsDate(string.Empty, value, info, styles);
        }

        public Validator IsDate(string name, object value, CultureInfo info, DateTimeStyles styles)
        {
            return IsDate(name, value, string.Format(MessageContainer.IsDateMessage, name), info, styles);
        }

        public Validator IsDate(string name, object value, string message, CultureInfo info, DateTimeStyles styles)
        {
            // do the check
            if (value.IsDate(info, styles))
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

        #region " IsGreaterThan "

        #endregion

        #region " IsLessThan "

        #endregion

        #region " IsEqualToDate "

        #endregion

        #region " IsInBetween "

        #endregion
    }
}
