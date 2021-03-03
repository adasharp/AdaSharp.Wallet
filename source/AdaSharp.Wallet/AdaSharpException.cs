using System;

namespace AdaSharp
{
    public class AdaSharpException : Exception
    {
        public AdaSharpException(string message)
            : base(message)
        { }

        public AdaSharpException(string message, Exception innerEx)
            : base(message, null)
        { }
    }
}