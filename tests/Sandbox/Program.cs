using System;
using System.Linq;
using AdaSharp;
using AdaSharp.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var node = new CardanoNodeEndpoint("192.168.15.138", 8090);

            IAdaSharpClient client = new AdaSharpClient(node);

            var response = client.Shelley.Wallets.GetAll();
        }
    }
}
