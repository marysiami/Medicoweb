using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Medicoweb.Common.Exceptions
{
    public class InvalidCreateHospitalException : Exception
    {
        public InvalidCreateHospitalException()
        {
        }

        public InvalidCreateHospitalException(string message) : base(message)
        {
        }

        public InvalidCreateHospitalException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidCreateHospitalException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
