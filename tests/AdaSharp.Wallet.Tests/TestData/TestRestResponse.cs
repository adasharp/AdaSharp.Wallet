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
            return LoadHttpResponseFrom(bodyContentFilePath, HttpStatusCode.OK);
        }

        public static IRestResponse LoadHttp406From(string bodyContentFilePath)
        {
            return LoadHttpResponseFrom(bodyContentFilePath, HttpStatusCode.NotAcceptable);
        }

        public static IRestResponse LoadHttp404From(string bodyContentFilePath)
        {
            return LoadHttpResponseFrom(bodyContentFilePath, HttpStatusCode.NotFound);
        }

        public static IRestResponse LoadHttp400From(string bodyContentFilePath)
        {
            return LoadHttpResponseFrom(bodyContentFilePath, HttpStatusCode.BadRequest);
        }

        private static IRestResponse LoadHttpResponseFrom(string bodyContentFilePath, HttpStatusCode statusCode)
        {
            var bodyContent = File.ReadAllText(bodyContentFilePath);

            return MockRestResponse(statusCode, bodyContent);
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