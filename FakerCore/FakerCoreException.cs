using System;
using System.Runtime.Serialization;

namespace FakerLib
{
    public class FakerCoreException : Exception
    {
        public FakerCoreException()
        {
        }

        protected FakerCoreException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public FakerCoreException(string? message) : base(message)
        {
        }

        public FakerCoreException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}