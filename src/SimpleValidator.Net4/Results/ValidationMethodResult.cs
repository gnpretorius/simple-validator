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
        }

        public ValidationMethodResult(T result)
            : this()
        {
            Result = result;
        }

        public ValidationMethodResult(Validator validator)
            : this()
        {
            Validator = validator;
        }

        public ValidationMethodResult(Validator validator, T result)
            : this()
        {
            Validator = validator;
            Result = result;
        }

        #endregion

        #region " Properties "

        public T Result { get; set; }
        public Validator Validator;
        
        public bool IsValid
        {
            get
            {
                if (Validator == null)
                {
                    return true;
                }

                return Validator.IsValid;
            }
        }

        public List<ValidationError> Errors 
        {
            get
            {
                if (Validator == null)
                {
                    return new List<ValidationError>();
                }

                return Validator.Errors;
            }
        }

        public List<ValidationError> UniqueErrors
        {
            get
            {
                if (Validator == null)
                {
                    return new List<ValidationError>();
                }

                return Validator.UniqueErrors;
            }
        }

        #endregion
    }
}
