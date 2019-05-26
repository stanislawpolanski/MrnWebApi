using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrnWebApi.Common.Exceptions
{
    public class ForbiddenUseOfCharacterInStringException : ArgumentException
    {
        public ForbiddenUseOfCharacterInStringException(string message) : base(message)
        {
        }
    }
}
