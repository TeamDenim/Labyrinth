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
            using (var stringWriter = new StringWriter())
            {
                var counter = 0;
                Console.SetOut(stringWriter);

                var interpreter = new LabyrinthEngine();
                interpreter.ExecuteCommand("fskdfnk", ref counter);

                var expected = Messages.INVALID_INPUT;

                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void TestTopScoreCommandExecution()
        {
            using (var stringWriter = new StringWriter())
            {
                var counter = 0;
                Console.SetOut(stringWriter);
                var scoreBoard = new Scoreboard();
                var interpreter = new LabyrinthEngine();
                interpreter.ExecuteCommand("TOP", ref counter);
                var expected = Messages.SCOREBOARD_EMPTY_MESSAGE;
                var actual = scoreBoard.PrintScore();

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void TestExitCommandExecution()
        {
            using (var stringWriter = new StringWriter())
            {
                var counter = 0;
                Console.SetOut(stringWriter);
                var scoreBoard = new Scoreboard();
                var interpreter = new LabyrinthEngine();
                interpreter.ExecuteCommand("EXIT", ref counter);
                var expected = "";

                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }
    }
}
