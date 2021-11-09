using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Exceptions
{
    public class NotGeneratedCardException : Exception
    {
        public NotGeneratedCardException()
        {
        }

        public NotGeneratedCardException(string message) : base(message)
        {
        }

        public NotGeneratedCardException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
