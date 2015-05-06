namespace Labyrinth.Tests
{
    using System;
    using System.IO;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Wintellect.PowerCollections;

    [TestClass]
    public class ScoreboardTests
    {
        [TestMethod]
        public void TestGetLastScore()
        {
            using (var stringWriter = new StringWriter())
            {
                var expected = "";
                var actual = stringWriter.ToString();

                Assert.AreEqual(expected, actual);
            }
        }

        public void FillDictionary()
        {
            
        }
    }
}
