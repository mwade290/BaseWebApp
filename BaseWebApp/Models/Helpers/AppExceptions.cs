using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseWebApp.Models.Helpers
{
    public class BaseWebAppException : Exception
    {
        public BaseWebAppException(string message) : base(message)
        {
        }

        public BaseWebAppException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

