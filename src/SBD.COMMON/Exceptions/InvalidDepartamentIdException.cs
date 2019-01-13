using System;
using System.Runtime.Serialization;

namespace SBD.WEB.Controllers
{
   
    public class InvalidDepartmanetIdException : Exception
    {
        public InvalidDepartmanetIdException()
        {
        }

        public InvalidDepartmanetIdException(string message) : base(message)
        {
        }

        public InvalidDepartmanetIdException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidDepartmanetIdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}