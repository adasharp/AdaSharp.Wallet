using AdaSharp.Network;

namespace AdaSharp.Tests.TestData
{
    public static class TestEpoch
    {
        public static Epoch Allegra => TestFile.LoadFrom<Epoch>(@"TestData\Epoch-Allegra.json");

        public static Epoch Mary => TestFile.LoadFrom<Epoch>(@"TestData\Epoch-Mary.json");

        public static Epoch Byron => TestFile.LoadFrom<Epoch>(@"TestData\Epoch-Byron.json");

        public static Epoch Shelley => TestFile.LoadFrom<Epoch>(@"TestData\Epoch-Shelley.json");
    }
}