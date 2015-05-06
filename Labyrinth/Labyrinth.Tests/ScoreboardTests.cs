namespace Labyrinth.Tests
{
    using System;
    using System.IO;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Wintellect.PowerCollections;
    using Labyrinth.Common.ScoreBoard;

    [TestClass]
    public class ScoreboardTests
    {
        [TestMethod]
        public void TestUpdateScoreBoard()
        {
            Scoreboard scoreBoard = new Scoreboard();
            scoreBoard.UpdateScoreBoard(15);
            scoreBoard.UpdateScoreBoard(13);
            scoreBoard.UpdateScoreBoard(10);
            scoreBoard.UpdateScoreBoard(20);
            Assert.AreEqual(4, scoreBoard.ScoreBoard.Count, "The count must be 4!");
        }
    }
}
