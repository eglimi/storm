using System;
using System.Runtime.Serialization;

namespace Storm.Lib
{
    /// <summary>
    /// Summary description for Exceptions.
    /// </summary>
    public class ConcurrencyException : ApplicationException
    {
        public ConcurrencyException()
            : base("Concurrency Exception")
        {
        }

        public ConcurrencyException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected ConcurrencyException(SerializationInfo serInfo, StreamingContext scontext)
            : base(serInfo, scontext)
        {
        }
    }
}
