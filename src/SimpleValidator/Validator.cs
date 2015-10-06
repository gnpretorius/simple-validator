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

        #region " IsNotNullOrEmpty "

        public Validator IsNotNullOrEmpty(string value)
        {
            return IsNotNullOrEmpty("", value);
        }

        public Validator IsNotNullOrEmpty(string name, string value)
        {
            return IsNotNullOrEmpty(name, value, string.Format(MessageContainer.IsNotNullOrEmptyMessage, name));
        }

        public Validator IsNotNullOrEmpty(string name, string value, string message)
        {
            // do the check
            if (value.IsNotNullOrEmpty())
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

        #region " IsNotEmpty "

        public Validator IsNullOrWhiteSpace(string value)
        {
            return IsNullOrWhiteSpace("", value);
        }

        public Validator IsNullOrWhiteSpace(string name, string value)
        {
            return IsNullOrWhiteSpace(name, value, string.Format(MessageContainer.IsNotNullOrWhiteSpaceMessage, name));
        }

        public Validator IsNullOrWhiteSpace(string name, string value, string message)
        {
            // do the check
            if (value.IsNotNullOrWhiteSpace())
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
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
            return IsEmail(name, value, string.Format(MessageContainer.IsEmailMessage, name));
        }

        public Validator IsEmail(string name, string value, string message)
        {
            // do the check
            if (value.IsEmail())
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
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
            return NotZero(name, value, string.Format(MessageContainer.IsNotZeroMessage, name));
        }

        public Validator NotZero(string name, int value, string message)
        {
            // do the check
            if (value.IsNotZero())
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

        #region " IsRegex "

        public Validator IsRegex(string value, string exp)
        {
            return IsRegex("", value, exp);
        }

        public Validator IsRegex(string name, string value, string exp)
        {
            return IsRegex(name, value, exp, string.Format(MessageContainer.IsRegexMessage, name));
        }

        public Validator IsRegex(string name, string value, string exp, string message)
        {
            // do the check
            if (value.IsRegex(exp))
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

        #region " IsPassword "

        public Validator IsPassword(string value)
        {
            return IsPassword("", value);
        }

        public Validator IsPassword(string name, string value)
        {
            return IsPassword(name, value, string.Format(MessageContainer.IsPasswordMessage, name));
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

        #region " IsEqualTo "

        public Validator IsMatch(string value, string compare)
        {
            return IsMatch("", value, compare);
        }

        public Validator IsMatch(string name, string value, string compare)
        {
            return IsMatch(name, value, compare, string.Format(MessageContainer.IsMatchMessage, name));
        }

        public Validator IsMatch(string name, string value, string compare, string message)
        {
            // do the check
            if (!value.IsEqualTo(compare))
            {
                return AddError(name, message);
            }
            else
            {
                return NoError();
            }
        }

        #endregion

        #region " IsMinLength "

        public Validator IsMinLength(string value, int min)
        {
            return IsMinLength("", value, min);
        }

        public Validator IsMinLength(string name, string value, int min)
        {
            return IsMinLength(name, value, min, string.Format(MessageContainer.IsMinLengthMessage, name, min));
        }

        public Validator IsMinLength(string name, string value, int min, string message)
        {
            // do the check
            if (value.IsMinLength(min))
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

        #region " IsMaxLength "

        public Validator IsMaxLength(string value, int max)
        {
            return IsMaxLength("", value, max);
        }

        public Validator IsMaxLength(string name, string value, int max)
        {
            return IsMaxLength(name, value, max, string.Format(MessageContainer.IsMaxLengthMessage, name, max));
        }

        public Validator IsMaxLength(string name, string value, int max, string message)
        {
            // do the check
            if (value.IsMaxLength(max))
            {
                return NoError();
                
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

        #region " IsBetweenLength "

        public Validator IsBetweenLength(string value, int min, int max)
        {
            return IsBetweenLength("", value, min, max);
        }

        public Validator IsBetweenLength(string name, string value, int min, int max)
        {
            return IsBetweenLength(name, value, min, max, string.Format(MessageContainer.IsBetweenLengthMessage, name, min, max));
        }

        public Validator IsBetweenLength(string name, string value, int min, int max, string message)
        {
            // do the check
            if (value.IsBetweenLength(min, max))
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
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
            return IsExactLength(name, value, exact, string.Format(MessageContainer.IsExactLengthMessage, name, exact));
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

        public void ThrowValidationExceptionIfInvalid()
        {
            if (!IsValid)
            {
                throw new Exceptions.ValidationException(this);
            }
        }

        protected Validator NoError()
        {
            _LastError = null;
            return this;
        }

        #endregion
    }
}
