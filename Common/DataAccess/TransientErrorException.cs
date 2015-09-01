using System;
using System.Runtime.Serialization;

namespace Common.DataAccess
{
    public class TransientErrorException : Exception
    {
        public TransientErrorException()
        {
        }

        public TransientErrorException(string message)
            : base(message)
        {
        }

        public TransientErrorException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected TransientErrorException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}