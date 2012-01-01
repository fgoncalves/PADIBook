using System;
using System.Runtime.Serialization;

namespace PADIBook.Utils.Exceptions
{
    [Serializable]
    public class ServiceUnavailableException : Exception
    {
        public ServiceUnavailableException() : base() { }

        public ServiceUnavailableException(string msg) : base(msg) { }

        public ServiceUnavailableException(SerializationInfo info, StreamingContext ctxt)
            : base(info,ctxt) { }
    }
}
