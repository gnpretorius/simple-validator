using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleValidator.Results
{
    public class ValidationError
    {
        public ValidationError()
        {
            Name = "";
            Message = "";
        }

        public string Name { get; set; }
        public string Message { get; set; }

        #region " Helpers "

        public static ValidationError Create(string name, string message)
        {
            ValidationError error = new ValidationError()
            {
                Name = name,
                Message = message
            };

            return error;
        }

        #endregion
    }
}
