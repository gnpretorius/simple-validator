using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleValidator.Results
{
    public class ValidationMethodResult<T>
    {
        #region " Constructor "

        public ValidationMethodResult()
        {
            IsValid = false;
            Errors = new List<ValidationError>();
        }

        public ValidationMethodResult(bool isValid, T result)
            : this()
        {
            Result = result;
            IsValid = isValid;
        }

        public ValidationMethodResult(bool isValid, List<ValidationError> errors, T result)
            : this()
        {
            Result = result;
            IsValid = isValid;
            Errors = errors;
        }

        public ValidationMethodResult(Validator validator)
            : this()
        {
            IsValid = validator.IsValid;
            Errors = validator.Errors;
        }

        public ValidationMethodResult(Validator validator, T result)
            : this()
        {
            IsValid = validator.IsValid;
            Errors = validator.Errors;
            Result = result;
        }

        #endregion
        
        #region " Properties "

        public bool IsValid { get; set; }
        public List<ValidationError> Errors { get; set; }
        public T Result { get; set; }

        #endregion
    }
}
