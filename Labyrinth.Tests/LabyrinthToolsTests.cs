using System;
using Labyrinth.Common.Interfaces;
using Labyrinth.Common.Player;
using Xunit;

namespace Labyrinth.Tests
{
    using Common.LabyrinthTools;
    using Common.Constants;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LabyrinthToolsTests
    {
        [TestMethod]
        public void GenerateLabyrinthMoreThenOneStartSymbolTest()
        {
            LabyrinthTools labyrinth = new LabyrinthTools();

            char[,] matrix = labyrinth.GenerateLabyrinth();

            int startSymbolCount = 0;

            foreach (var symbol in matrix)
            {
                if (symbol == LabyrinthConstants.PLAYER_SIGN_CHAR)
                {
                    startSymbolCount++;
                    if (startSymbolCount > 1)
                    {
                        Assert.AreEqual(startSymbolCount, 1, "you have more then one start symbol, pleace check your code");
                    }
                    else
                    {
                        Assert.AreEqual(startSymbolCount, 1, "You have only one start symbol");
                    }
                }
            }
        }

        [TestMethod]
        public void GenerateLabyrinthForWrongTypeItemTest()
        {
            LabyrinthTools labyrinth = new LabyrinthTools();

            char[,] matrix = labyrinth.GenerateLabyrinth();

            bool wrongItem = false;
            foreach (var symbol in matrix)
            {
                if (symbol == LabyrinthConstants.BLOCKED_CELL_CHAR || symbol == LabyrinthConstants.FREE_CELL_CHAR ||
                    symbol == LabyrinthConstants.PLAYER_SIGN_CHAR)
                {
                    Assert.IsTrue(wrongItem == false, "the labyrinth has the right items");
                }
                else
                {
                    wrongItem = true;
                    Assert.IsTrue(wrongItem == true, "there is wrong item or items, pleace check labyrinth items again");
                }
            }
        }

        [TestMethod]
        public void PrintLabyrinthTest()
        {
            LabyrinthTools labyrinth = new LabyrinthTools();
            char[,] matrix = labyrinth.GenerateLabyrinth();

            IPlayer player = new Player(matrix);

            labyrinth.PrintLabirynth(player);

            bool wrongItem = false;
            foreach (var symbol in matrix)
            {
                if (symbol == LabyrinthConstants.BLOCKED_CELL_CHAR || symbol == LabyrinthConstants.FREE_CELL_CHAR ||
                    symbol == LabyrinthConstants.PLAYER_SIGN_CHAR)
                {
                    Assert.IsTrue(wrongItem == false, "the player has the right items");
                }
                else
                {
                    wrongItem = true;
                    Assert.IsTrue(wrongItem == true, "there is wrong item or items, pleace check the print labyrinth method again");
                }
            }
        }

        [Theory]
        [InlineData(-1, -1)]
        [InlineData(-1, LabyrinthConstants.LABYRINTH_SIZE)]
        [InlineData(LabyrinthConstants.LABYRINTH_SIZE, -1)]
        [InlineData(LabyrinthConstants.LABYRINTH_SIZE, LabyrinthConstants.LABYRINTH_SIZE)]
        public void IsGameOverTest(int positionX, int positionY)
        {
            LabyrinthTools labyrinth = new LabyrinthTools();
            bool wantedResult = true;

            bool currentResult = labyrinth.IsGameOver(positionX, positionY);

            Assert.AreEqual(wantedResult, currentResult, "The method works correct for these parameters");
        }
    }
}
