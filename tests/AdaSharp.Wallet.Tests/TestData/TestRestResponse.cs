using System.IO;
using System.Net;
using Moq;
using RestSharp;

namespace AdaSharp.Tests.TestData
{
    public class TestRestResponse
    {
        public static IRestResponse LoadHttp200From(string bodyContentFilePath)
        {
            var bodyContent = File.ReadAllText(bodyContentFilePath);

            return MockRestResponse(HttpStatusCode.OK, bodyContent);
        }

        public static IRestResponse LoadHttp406From(string bodyContentFilePath)
        {
            var bodyContent = File.ReadAllText(bodyContentFilePath);

            return MockRestResponse(HttpStatusCode.NotAcceptable, bodyContent);
        }

        private static IRestResponse MockRestResponse(HttpStatusCode statusCode, string content)
        {
            var mockedResponse = new Mock<IRestResponse>();

            mockedResponse
                .Setup(m => m.StatusCode)
                .Returns(statusCode);

            mockedResponse
                .Setup(m => m.Content)
                .Returns(content);

            return mockedResponse.Object;
        }
    }
}