using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Exceptions
{
    public class GetPathFailedException : Exception
    {
        private string pathName;

        public GetPathFailedException(string pathName)
        {
            this.pathName = pathName;
        }

        public GetPathFailedException(string message, string pathName) : base(message)
        {
            this.pathName = pathName;
        }

        public GetPathFailedException(string message, Exception innerException, string pathName) : base(message, innerException)
        {
            this.pathName = pathName;
        }
    }
}
