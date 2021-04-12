using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FileUserStore.Helpers.Exceptions
{
    public class PhonenumberVerificationException : Exception
    {
        public PhonenumberVerificationException()
        {
        }

        public PhonenumberVerificationException(string message) : base(message)
        {
        }

        public PhonenumberVerificationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PhonenumberVerificationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
