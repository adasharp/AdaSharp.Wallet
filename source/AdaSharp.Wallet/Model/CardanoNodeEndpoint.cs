using System;
using System.Net;
using System.Net.Sockets;

namespace AdaSharp.Model
{
    public sealed class CardanoNodeEndpoint : DnsEndPoint
    {
        // TODO: Add support for IPv6.
        public CardanoNodeEndpoint(string host, int port)
            : base(host, port, AddressFamily.InterNetwork)
        { }

        public Uri ToUri(bool useHttps = false)
        {
            var protocol = useHttps
                ? "https"
                : "http";

            // TODO: Correct version.
            var uriValue = $"{protocol}://{Host}:{Port}/v2";

            return new Uri(uriValue);
        }
    }
}