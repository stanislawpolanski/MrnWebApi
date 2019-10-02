using System;

namespace DatabaseAPI.Inner.Common.Exceptions
{
    public class ForbiddenUseOfCharacterInAStringException : ArgumentException
    {
        public ForbiddenUseOfCharacterInAStringException(string message) : base(message)
        {
        }
    }
}
