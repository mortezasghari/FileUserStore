using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FileUserStore.Helpers.Extentions
{
    public class EmailVerificationException : Exception
    {
        public EmailVerificationException()
        {
        }

        public EmailVerificationException(string message) : base(message)
        {
        }

        public EmailVerificationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmailVerificationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
