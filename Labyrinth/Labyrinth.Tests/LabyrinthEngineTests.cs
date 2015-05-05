namespace Labyrinth.Tests
{
    using System;
    using System.IO;
    using Labyrinth.Common;
    using Labyrinth.Common.Constants;
    using Labyrinth.Common.ScoreBoard;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LabyrinthEngineTests
    {
        [TestMethod]
        public void TestInvalidCommandExecution()
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

        [TestMethod]
        public void TestTopScoreCommandExecution()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                int counter = 0;
                Console.SetOut(stringWriter);
                var scoreBoard = new Scoreboard();
                var interpreter = new LabyrinthEngine();
                interpreter.ExecuteCommand("TOP", ref counter);
                string expected = Messages.SCOREBOARD_EMPTY_MESSAGE;
                string actual = scoreBoard.PrintScore();

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void TestExitCommandExecution()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                int counter = 0;
                Console.SetOut(stringWriter);
                var scoreBoard = new Scoreboard();
                var interpreter = new LabyrinthEngine();
                interpreter.ExecuteCommand("EXIT", ref counter);
                string expected = "";

                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }
    }
}
