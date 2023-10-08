using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Exceptions
{
    public class SecureException : Exception
    {
        public SecureException(string message) : base(message)
        {

        }
        
    }
}