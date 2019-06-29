using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;

namespace SimpleValidator.Exceptions
{
    [Serializable]
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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="info">Serialization Info</param>
        /// <param name="context">Streaming Context</param>
        protected ValidationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }

        /// <summary>
        /// Get object data
        /// </summary>
        /// <param name="info">Serialization Info</param>
        /// <param name="context">context</param>
        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
