using SimpleValidator.Constants;
using SimpleValidator.Extensions;
using SimpleValidator.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SimpleValidator
{
    public class Validator
    {
        /// <summary>
        /// Validate properties and types using this class
        /// </summary>
        public Validator()
        {
            Errors = new List<ValidationError>();
        }

        #region " Properties "

        private ValidationError _LastError = null;

        public bool IsValid
        {
            get
            {
                return Errors.Count == 0;
            }
        }

        #endregion

        #region " Validation Errors "

        public List<ValidationError> Errors { get; set; }

        #endregion

        #region " NotNull "

        public Validator NotNull(object value)
        {
            return NotNull("", value);
        }

        public Validator NotNull(string name, object value)
        {
            return NotNull(name, value, string.Format(Messages.NotNullMessage, name));
        }

        public Validator NotNull(string name, object value, string message)
        {
            // do the check
            if (value.IsNull())
            {
                return AddError(name, message);
            }
            else
            {
                return NoError();
            }
        }

        #endregion

        #region " NotZero "

        public Validator NotZero(int value)
        {
            return NotZero("", value);
        }

        public Validator NotZero(string name, int value)
        {
            return NotZero(name, value, string.Format(Messages.NotZeroMessage, name));
        }

        public Validator NotZero(string name, int value, string message)
        {
            // do the check
            if (value.NotZero())
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

        #region " NotEmpty "

        public Validator NotEmpty(string value)
        {
            return NotEmpty("", value);
        }

        public Validator NotEmpty(string name, string value)
        {
            return NotEmpty(name, value, string.Format(Messages.NotEmptyMessage, name));
        }

        public Validator NotEmpty(string name, string value, string message)
        {
            // do the check
            if (value.IsEmpty())
            {
                return AddError(name, message);
            }
            else
            {
                return NoError();
            }
        }

        #endregion

        #region " IsEmail "

        public Validator IsEmail(string value)
        {
            return IsEmail("", value);
        }

        public Validator IsEmail(string name, string value)
        {
            return IsEmail(name, value, string.Format(Messages.IsEmailMessage, name));
        }

        public Validator IsEmail(string name, string value, string message)
        {
            // do the check
            if (!value.IsEmail())
            {
                return AddError(name, message);
            }
            else
            {
                return NoError();
            }
        }

        #endregion

        #region " IsEmail "

        public Validator IsPassword(string value)
        {
            return IsPassword("", value);
        }

        public Validator IsPassword(string name, string value)
        {
            return IsPassword(name, value, string.Format(Messages.IsPasswordMessage, name));
        }

        public Validator IsPassword(string name, string value, string message)
        {
            // do the check
            if (!value.IsPassword())
            {
                return AddError(name, message);
            }
            else
            {
                return NoError();
            }
        }

        #endregion

        #region " IsMatch "

        public Validator IsMatch(string value, string compare)
        {
            return IsMatch("", value, compare);
        }

        public Validator IsMatch(string name, string value, string compare)
        {
            return IsMatch(name, value, compare, string.Format(Messages.IsMatchMessage, name));
        }

        public Validator IsMatch(string name, string value, string compare, string message)
        {
            // do the check
            if (!value.IsMatch(compare))
            {
                return AddError(name, message);
            }
            else
            {
                return NoError();
            }
        }

        #endregion

        #region " IsLength "

        public Validator IsLength(string value, int min)
        {
            return IsLength("", value, min);
        }

        public Validator IsLength(string name, string value, int min)
        {
            return IsLength(name, value, min, string.Format(Messages.IsLengthMinMessage, name, min));
        }

        public Validator IsLength(string name, string value, int min, string message)
        {
            // do the check
            if (!value.IsLength(min))
            {
                return AddError(name, message);
            }
            else
            {
                return NoError();
            }
        }

        public Validator IsLength(string value, int min, int max)
        {
            return IsLength("", value, min, max);
        }

        public Validator IsLength(string name, string value, int min, int max)
        {
            return IsLength(name, value, min, max, string.Format(Messages.IsLengthMinMaxMessage, name, min, max));
        }

        public Validator IsLength(string name, string value, int min, int max, string message)
        {
            // do the check
            if (!value.IsLength(min, max))
            {
                return AddError(name, message);
            }
            else
            {
                return NoError();
            }
        }

        #endregion

        #region " IsExactLength "

        public Validator IsExactLength(string value, int exact)
        {
            return IsExactLength("", value, exact);
        }

        public Validator IsExactLength(string name, string value, int exact)
        {
            return IsExactLength(name, value, exact, string.Format(Messages.NotEmptyMessage, name, exact));
        }

        public Validator IsExactLength(string name, string value, int exact, string message)
        {
            // do the check
            if (!value.IsExactLength(exact))
            {
                return AddError(name, message);
            }
            else
            {
                return NoError();
            }
        }

        #endregion

        #region " Must "

        public Validator Must(Func<bool> func)
        {
            return Must("", func);
        }

        public Validator Must(string name, Func<bool> func)
        {
            return Must(name, func, Messages.MustMessage);
        }

        public Validator Must(string name, Func<bool> func, string message)
        {
            // do the check
            if (func())
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

        #region " MustNot "

        public Validator MustNot(Func<bool> func)
        {
            return MustNot("", func);
        }

        public Validator MustNot(string name, Func<bool> func)
        {
            return MustNot(name, func, Messages.MustNotMessage);
        }

        public Validator MustNot(string name, Func<bool> func, string message)
        {
            // do the check
            if (func())
            {
                return AddError(name, message);
            }
            else
            {
                return NoError();
            }
        }

        #endregion

        #region " WithMessage "

        public Validator WithMessage(string message)
        {
            if (_LastError != null)
            {
                _LastError.Message = message;
            }

            return this;
        }

        #endregion

        #region " Helpers "

        public Validator AddError(string message)
        {
            return AddError("", message);
        }

        public Validator AddError(string name, string message)
        {
            ValidationError error = ValidationError.Create(name.EmptyStringIfNull(), message);
            Errors.Add(error);
            _LastError = error;

            return this;
        }

        protected Validator NoError()
        {
            _LastError = null;
            return this;
        }

        #endregion
    }
}
