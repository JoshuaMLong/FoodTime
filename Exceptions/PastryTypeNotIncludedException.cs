using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.API.Exceptions
{
    public class PastryTypeNotIncludedException : Exception
    {
        public PastryTypeNotIncludedException()
        {
        }

        public PastryTypeNotIncludedException(string message) : base(message)
        {
        }

        public PastryTypeNotIncludedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PastryTypeNotIncludedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
