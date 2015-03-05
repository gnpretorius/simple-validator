using SimpleValidator.Constants;
using SimpleValidator.Extensions;
using SimpleValidator.Results;
using System;
using System.Collections.Generic;
using System.Linq;
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

        #endregion

        #region " Validation Errors "

        public List<ValidationError> Errors { get; set; }

        #endregion

        #region " NotNull "

        public Validator NotNull(string value)
        {
            return NotNull("", value);
        }

        public Validator NotNull(string name, string value)
        {
            return NotNull(name, value, Messages.NotEmptyMessage);
        }

        public Validator NotNull(string name, string value, string message)
        {
            // do the check
            if (value.IsNull())
            {
                AddError(name, message);
            }
            else
            {
                NoError();
            }

            return this; // allow for chaining
        }

        #endregion

        #region " NotEmpty "

        public Validator NotEmpty(string value)
        {
            return NotEmpty("", value);
        }

        public Validator NotEmpty(string name, string value)
        {
            return NotEmpty(name, value, Messages.NotEmptyMessage);
        }

        public Validator NotEmpty(string name, string value, string message)
        {
            // do the check
            if (value.IsEmpty())
            {
                AddError(name, message);
            }
            else
            {
                NoError();
            }

            return this; // allow for chaining
        }

        #endregion

        #region " IsEmail "

        public Validator IsEmail(string value)
        {
            return IsEmail("", value);
        }

        public Validator IsEmail(string name, string value)
        {
            return IsEmail(name, value, Messages.NotEmptyMessage);
        }

        public Validator IsEmail(string name, string value, string message)
        {
            // do the check
            if (!value.IsEmail())
            {
                AddError(name, message);
            }
            else
            {
                NoError();
            }

            return this; // allow for chaining
        }

        #endregion

        #region " IsLength "

        public Validator IsLength(string value, int min)
        {
            return IsLength("", value, min);
        }

        public Validator IsLength(string name, string value, int min)
        {
            return IsLength(name, value, min, Messages.NotEmptyMessage);
        }

        public Validator IsLength(string name, string value, int min, string message)
        {
            // do the check
            if (!value.IsLength(min))
            {
                AddError(name, message);
            }
            else
            {
                NoError();
            }

            return this; // allow for chaining
        }

        public Validator IsLength(string value, int min, int max)
        {
            return IsLength("", value, min, max);
        }

        public Validator IsLength(string name, string value, int min, int max)
        {
            return IsLength(name, value, min, max, Messages.NotEmptyMessage);
        }

        public Validator IsLength(string name, string value, int min, int max, string message)
        {
            // do the check
            if (!value.IsLength(min, max))
            {
                AddError(name, message);
            }
            else
            {
                NoError();
            }

            return this; // allow for chaining
        }

        #endregion

        #region " IsExactLength "

        public Validator IsExactLength(string value, int exact)
        {
            return IsExactLength("", value, exact);
        }

        public Validator IsExactLength(string name, string value, int exact)
        {
            return IsExactLength(name, value, exact, Messages.NotEmptyMessage);
        }

        public Validator IsExactLength(string name, string value, int exact, string message)
        {
            // do the check
            if (!value.IsExactLength(exact))
            {
                AddError(name, message);
            }
            else
            {
                NoError();
            }

            return this; // allow for chaining
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

        protected void AddError(string message)
        {
            AddError("", message);
        }

        protected void AddError(string name, string message)
        {
            ValidationError error = ValidationError.Create(name.EmptyStringIfNull(), message);
            Errors.Add(error);
            _LastError = error;
        }

        protected void NoError()
        {
            _LastError = null;
        }

        #endregion
    }
}
