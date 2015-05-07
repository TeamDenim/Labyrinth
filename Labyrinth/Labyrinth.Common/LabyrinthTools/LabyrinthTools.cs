namespace Labyrinth.Common.LabyrinthTools
{
    using System;
    using Labyrinth.Common.Interfaces;
    using Labyrinth.Common.Constants;

    /// <summary>
    /// 
    /// </summary>
    public sealed class LabyrinthTools : ILabyrinthTools
    {
        private const int numberOfDirections = 4;
        private const int maximumTimesToChangeAfter = 2;

        private char[,] labyrinth;

        public LabyrinthTools()
        {
            this.labyrinth = this.GenerateLabyrinth();
        }

        public char[,] Labyrinth
        {
            get { return this.labyrinth; }
        }

        public char[,] GenerateLabyrinth()
        {
            var generatedMatrix = new char[LabyrinthConstants.LABYRINTH_SIZE, LabyrinthConstants.LABYRINTH_SIZE];
            var randomNumberGenerator = new Random();
            var percentageOfBlockedCells = randomNumberGenerator.Next(LabyrinthConstants.MINIMUM_PERCENTAGE_OF_BLOCKED_CELLS,
                LabyrinthConstants.MAXIMUM_PERCENTAGE_OF_BLOCKED_CELLS);

            for (var row = 0; row < LabyrinthConstants.LABYRINTH_SIZE; row++)
            {
                for (var col = 0; col < LabyrinthConstants.LABYRINTH_SIZE; col++)
                {
                    var randomNumber = randomNumberGenerator.Next(0, 100); // for cheking whether the cell will be blocked or free

                    if (randomNumber < percentageOfBlockedCells)
                    {
                        generatedMatrix[row, col] = LabyrinthConstants.BLOCKED_CELL_CHAR;
                    }
                    else
                    {
                        generatedMatrix[row, col] = LabyrinthConstants.FREE_CELL_CHAR;
                    }

                }
            }

            generatedMatrix[LabyrinthConstants.PLAYER_START_POSITION_X, LabyrinthConstants.PLAYER_START_POSITION_Y] 
                = LabyrinthConstants.PLAYER_SIGN_CHAR;

            this.MakeAtLeastOneExitReachable(generatedMatrix);
            return generatedMatrix;
        }

        private void MakeAtLeastOneExitReachable(char[,] generatedMatrix)
        {
            var randomNumberGenerator = new Random();
            var pathX = LabyrinthConstants.PLAYER_START_POSITION_X;
            var pathY = LabyrinthConstants.PLAYER_START_POSITION_Y;
            int[] dirX = { 0, 0, 1, -1 };
            int[] dirY = { 1, -1, 0, 0 };

            while (this.IsGameOver(pathX, pathY) == false)
            {
                var times = randomNumberGenerator.Next(0, maximumTimesToChangeAfter);

                {


                    if (generatedMatrix[pathY, pathX] != LabyrinthConstants.PLAYER_SIGN_CHAR)
                    {
                        generatedMatrix[pathY, pathX] = LabyrinthConstants.FREE_CELL_CHAR;
                    }
                }
                
            }
        }

        public void PrintLabirynth(IPlayer player)
        {
            //Console.WriteLine(Messages.WELCOME_MESSAGE);
            //Console.WriteLine(Messages.COMMAND_INFO_MESSAGE);
            for (var row = 0; row < LabyrinthConstants.LABYRINTH_SIZE; row++)
            {
                for (var col = 0; col < LabyrinthConstants.LABYRINTH_SIZE; col++)
                {
                    Console.Write("{0,2}", player.CurrentLabyrinth[row, col]);
                }
                Console.WriteLine();
            }
        }

        public bool IsGameOver(int playerPositionX, int playerPositionY)
        {
            return (playerPositionX <= 0 || playerPositionX >= LabyrinthConstants.LABYRINTH_SIZE - 1) 
                || (playerPositionY <= 0 || playerPositionY >= LabyrinthConstants.LABYRINTH_SIZE - 1);
        }
    }
}
