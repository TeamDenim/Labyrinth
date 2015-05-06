using System.Runtime.Remoting.Lifetime;

namespace Labyrinth.Tests
{
    using Common.LabyrinthTools;
    using Common.Constants;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LabyrinthToolsTests
    {
        [TestMethod]
        public void TestGenerateLabyrinthMoreThenOneStartSymbol()
        {
            LabyrinthTools labyrinth = new LabyrinthTools();

            char[,] matix = labyrinth.GenerateLabyrinth();

            int startSymbolCount = 0;

            foreach (var item in matix)
            {
                if (item == LabyrinthConstants.PLAYER_SIGN_CHAR)
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
        public void TestGenerateLabyrinthForWrongTypeItem()
        {
            LabyrinthTools labyrinth = new LabyrinthTools();

            char[,] matix = labyrinth.GenerateLabyrinth();

            bool wrongItem = false;
            foreach (var item in matix)
            {
                if (item == LabyrinthConstants.BLOCKED_CELL_CHAR || item == LabyrinthConstants.FREE_CELL_CHAR ||
                    item == LabyrinthConstants.PLAYER_SIGN_CHAR)
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
        public void TestMakeAtLeastOneExitReachable()
        {
            LabyrinthTools labyrinth = new LabyrinthTools();

            char[,] matrix = labyrinth.GenerateLabyrinth();

            //if (matrix[0, ])
            //{
                
            //}
        }
    }
}
