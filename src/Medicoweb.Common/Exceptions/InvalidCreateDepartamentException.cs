﻿using System;
using System.Runtime.Serialization;

namespace Medicoweb.Common.Exceptions
{
    public class InvalidCreateDepartamentException : Exception

    {
        public InvalidCreateDepartamentException()
        {
        }

        public InvalidCreateDepartamentException(string message) : base(message)
        {
        }

        public InvalidCreateDepartamentException(string message, Exception innerException) : base(message,
            innerException)
        {
        }

        protected InvalidCreateDepartamentException(SerializationInfo info, StreamingContext context) : base(info,
            context)
        {
        }
    }
}