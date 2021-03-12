using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AdaSharp.Tests.TestData
{
    public static class TestMnemonicSeed
    {
        public static List<string> NominalSentence => GetNominalMnemonicSentence();
        public static List<string> NominalSecondFactor => GetNominalMnemonicSecondFactor();

        private static List<string> GetNominalMnemonicSentence()
        {
            var words = new[]
            {
                "squirrel",
                "material",
                "silly",
                "twice",
                "direct",
                "slush",
                "pistol",
                "razor",
                "become",
                "junk",
                "kingdom",
                "flee",
                "squirrel",
                "silly",
                "twice"
            };

            return words.ToList();
        }

        private static List<string> GetNominalMnemonicSecondFactor()
        {
            var words = new[]
            {
                "squirrel",
                "material",
                "silly",
                "twice",
                "direct",
                "slush",
                "pistol",
                "razor",
                "become"
            };

            return words.ToList();
        }
    }
}