using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.API.Exceptions
{
    public class PastryPriceCannotBeSetException : Exception
    {
        public PastryPriceCannotBeSetException()
        {
        }

        public PastryPriceCannotBeSetException(string message) : base(message)
        {
        }

        public PastryPriceCannotBeSetException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PastryPriceCannotBeSetException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
