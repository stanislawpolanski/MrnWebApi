using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrnWebApi.Common.Exceptions
{
    public class ForbiddenUseOfCharacterInAStringException : ArgumentException
    {
        public ForbiddenUseOfCharacterInAStringException(string message) : base(message)
        {
        }
    }
}
