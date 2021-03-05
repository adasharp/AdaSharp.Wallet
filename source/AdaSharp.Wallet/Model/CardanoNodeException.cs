using System.Net;

namespace AdaSharp.Model
{
    public class CardanoNodeException : AdaSharpException
    {
        public HttpStatusCode HttpStatusCode { get; }

        public string ErrorCode { get; }

        public CardanoNodeException(string errorCode, string errorMessage, HttpStatusCode httpStatusCode)
            : base(errorMessage)
        {
            HttpStatusCode = httpStatusCode;
            ErrorCode = errorCode;
        }
    }
}