using SimpleValidator.Extensions;
using SimpleValidator.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using SimpleValidator.Messages;
using SimpleValidator.Interfaces;

namespace SimpleValidator
{
    /// <summary>
    /// Always use the positive route i.e. a true result should indicate validity therefore generally prefix with "Is"
    /// e.g. This field is not zero
    /// </summary>
    public partial class Validator
    {
        #region " Constructor "

        /// <summary>
        /// Validate properties and types using this class
        /// </summary>
        public Validator()
        {
            Errors = new List<ValidationError>();
            MessageContainer = MessageFactory.Create();
        }

        public Validator(LanguageCodes code)
        {
            Errors = new List<ValidationError>();
            MessageContainer = MessageFactory.Create(code);
        }

        public Validator(MessageContainer container)
        {
            Errors = new List<ValidationError>();
            MessageContainer = container;
        }

        #endregion

        #region " Properties "

        public MessageContainer MessageContainer { get; set; }
       
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

        /// <summary>
        /// The full list of errors currently available
        /// </summary>
        public List<ValidationError> Errors { get; set; }

        /// <summary>
        /// Returns a list of errors with the specified name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<ValidationError> ErrorByName(string name)
        {
            return Errors.Where(o => o.Name == name).ToList();
        }

        /// <summary>
        /// This will return a unique set of Errors by Name and return the first instance of each error.
        /// </summary>
        public List<ValidationError> UniqueErrors
        {
            get
            {
                return Errors
                    .GroupBy(o => o.Name)
                    .Select(o => o.First())
                    .ToList();
            }
        }

        #endregion

        #region " Validation Methods "

        #region " IsNotNull "

        public Validator IsNotNull(object value)
        {
            return IsNotNull("", value);
        }

        public Validator IsNotNull(string name, object value)
        {
            return IsNotNull(name, value, string.Format(MessageContainer.IsNotNullMessage, name));
        }

        public Validator IsNotNull(string name, object value, string message)
        {
            // do the check
            if (value.IsNotNull())
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion
       
        #region " Is "

        public Validator Is(Func<bool> func)
        {
            return Is("", func);
        }

        public Validator Is(string name, Func<bool> func)
        {
            return Is(name, func, MessageContainer.IsMessage);
        }

        public Validator Is(string name, Func<bool> func, string message)
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

        #region " IsNot "

        public Validator IsNot(Func<bool> func)
        {
            return IsNot("", func);
        }

        public Validator IsNot(string name, Func<bool> func)
        {
            return IsNot(name, func, MessageContainer.IsNotMessage);
        }

        public Validator IsNot(string name, Func<bool> func, string message)
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

        #region " IsRule "

        public Validator IsRule(IRule rule)
        {
            return IsRule("", rule);
        }

        public Validator IsRule(string name, IRule rule)
        {
            return IsRule(name, rule, MessageContainer.IsRuleMessage);
        }

        public Validator IsRule(string name, IRule rule, string message)
        {
            // do the check
            if (name.IsRule(rule))
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

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

        public void ThrowValidationException()
        {
            throw new Exceptions.ValidationException(this);
        }

        /// <summary>
        /// Throws an exception if errors are found 
        /// </summary>
        /// <returns>If no errors are found it returns an instance of the validator. </returns>
        public Validator ThrowValidationExceptionIfInvalid()
        {
            if (!IsValid)
            {
                throw new Exceptions.ValidationException(this);
            }

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
