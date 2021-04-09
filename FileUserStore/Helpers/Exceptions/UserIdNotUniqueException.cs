using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FileUserStore.Helpers.Exceptions
{
    public class UserIdNotUniqueException : Exception
    {
        public UserIdNotUniqueException()
        {
        }

        public UserIdNotUniqueException(string message) : base(message)
        {
        }

        public UserIdNotUniqueException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserIdNotUniqueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
