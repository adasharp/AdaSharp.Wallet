using System;

namespace AdaSharp.Model
{
    public class InvalidRequestException : AdaSharpException
    {
        public InvalidRequestException(string message)
            : base(message)
        { }

        public InvalidRequestException(string message, Exception innerEx)
            : base(message, innerEx)
        { }
    }
}