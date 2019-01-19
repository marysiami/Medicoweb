using System;
using System.Runtime.Serialization;

namespace Medicoweb.Common.Exceptions
{
    public class InvalidGetPatientByIdException : Exception
    {
        public InvalidGetPatientByIdException()
        {
        }

        public InvalidGetPatientByIdException(string message) : base(message)
        {
        }

        public InvalidGetPatientByIdException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidGetPatientByIdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}