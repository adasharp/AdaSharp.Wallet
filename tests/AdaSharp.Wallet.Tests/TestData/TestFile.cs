using System.IO;
using Newtonsoft.Json;

namespace AdaSharp.Tests.TestData
{
    public static class TestFile
    {
        public static T LoadFrom<T>(string jsonFilePath)
        {
            var fileContents = File.ReadAllText(jsonFilePath);

            return JsonConvert.DeserializeObject<T>(fileContents);
        }
    }
}