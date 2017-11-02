using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleValidator.Exceptions
{
    public class ValidationException : Exception
    {
        public Validator Validator;

        private ValidationException()
        {
        }

        public ValidationException(Validator validator) : base()
        {
            Validator = validator;
        }
    }
}
