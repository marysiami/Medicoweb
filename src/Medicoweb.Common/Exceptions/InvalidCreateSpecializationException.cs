using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Medicoweb.Common.Exceptions
{
    public class InvalidCreateSpecializationException : Exception
    {
        public InvalidCreateSpecializationException()
        {
        }

        public InvalidCreateSpecializationException(string message) : base(message)
        {
        }

        public InvalidCreateSpecializationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidCreateSpecializationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
