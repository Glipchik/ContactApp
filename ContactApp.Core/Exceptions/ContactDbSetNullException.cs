using System.Runtime.Serialization;

namespace ContactApp.Core.Exceptions
{
    [Serializable]
    public class ContactDbSetNullException : Exception
    {
        public ContactDbSetNullException() { }

        public ContactDbSetNullException(string message) : base(message) { }

        public ContactDbSetNullException(string message, Exception innerException) : base(message, innerException) { }

        protected ContactDbSetNullException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
