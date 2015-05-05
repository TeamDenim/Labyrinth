namespace Labyrinth.Tests
{
    using System;
    using System.IO;
    using Labyrinth.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LabyrinthEngineTests
    {
        [TestMethod]
        public void TestCommandExecution()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                int counter = 0;
                Console.SetOut(stringWriter);

                var interpreter = new LabyrinthEngine();
                interpreter.ExecuteCommand("fskdfnk", ref counter);

                string expected = Messages.INVALID_INPUT;

                Assert.AreEqual(expected, stringWriter.ToString());
            }

        }
    }
}
