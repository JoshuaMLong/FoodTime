using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.API.Exceptions
{
    public class DbNotCreatedOrAccessibleException : Exception
    {
        public DbNotCreatedOrAccessibleException()
        {
        }

        public DbNotCreatedOrAccessibleException(string message) : base(message)
        {
        }

        public DbNotCreatedOrAccessibleException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DbNotCreatedOrAccessibleException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
