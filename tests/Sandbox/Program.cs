using System;
using AdaSharp;
using AdaSharp.Network;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var node = new CardanoNodeEndpoint("192.168.15.138", 8090);

            var client = new AdaSharpClient(node);

            var response = client.GetClock(new GetClockRequest());
        }
    }
}
