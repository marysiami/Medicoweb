using System;
using System.Runtime.Serialization;

namespace SBD.COMMON.Exceptions

{
 
    public class InvalidGetDoctorByIdException : Exception
    {
        public InvalidGetDoctorByIdException()
        {
        }

        public InvalidGetDoctorByIdException(string message) : base(message)
        {
        }

        public InvalidGetDoctorByIdException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidGetDoctorByIdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}