using System;

namespace DatabaseAPI.Common.Exceptions
{
    public class ForbiddenUseOfCharacterInAStringException : ArgumentException
    {
        public ForbiddenUseOfCharacterInAStringException(string message) : base(message)
        {
        }
    }
}
