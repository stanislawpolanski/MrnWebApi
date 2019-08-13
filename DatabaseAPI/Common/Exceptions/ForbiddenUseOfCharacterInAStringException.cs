using System;

namespace MrnWebApi.Common.Exceptions
{
    public class ForbiddenUseOfCharacterInAStringException : ArgumentException
    {
        public ForbiddenUseOfCharacterInAStringException(string message) : base(message)
        {
        }
    }
}
