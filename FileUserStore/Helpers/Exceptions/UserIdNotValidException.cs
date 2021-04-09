using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FileUserStore.Helpers.Exceptions
{
    public class UserIdNotValidException : Exception
    {
        public UserIdNotValidException()
        {
        }

        public UserIdNotValidException(string message) : base(message)
        {
        }

        public UserIdNotValidException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserIdNotValidException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
