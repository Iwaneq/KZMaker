using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Exceptions
{
    public class LoadFileFailedException : Exception
    {
        public LoadFileFailedException()
        {
        }

        public LoadFileFailedException(string message) : base(message)
        {
        }

        public LoadFileFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
