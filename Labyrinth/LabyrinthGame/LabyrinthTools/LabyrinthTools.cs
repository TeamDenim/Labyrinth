namespace Labyrinth.Common.LabyrinthTools
{
    using System;
    using Labyrinth.Common.Interfaces;

    public class LabyrinthTools : ILabyrinthTools
    {
        private IPlayer player;
        private char[,] labyrinth;

        public LabyrinthTools()
        {
            this.player = new Player(this.labyrinth);
            this.labyrinth = this.GenerateLabyrinth();
        }

        public char[,] Labyrinth 
        {
            get { return this.labyrinth; }
        }

        public virtual char[,] GenerateLabyrinth()
        {
            char[,] generatedMatrix = new char[LabyrinthConstants.LABYRINTH_SIZE, LabyrinthConstants.LABYRINTH_SIZE];
            Random rand = new Random();
            int percentageOfBlockedCells = rand.Next(LabyrinthConstants.MINIMUM_PERCENTAGE_OF_BLOCKED_CELLS,
                LabyrinthConstants.MAXIMUM_PERCENTAGE_OF_BLOCKED_CELLS);

            for (int row = 0; row < LabyrinthConstants.LABYRINTH_SIZE; row++)
            {
                for (int col = 0; col < LabyrinthConstants.LABYRINTH_SIZE; col++)
                {
                    int num = rand.Next(0, 100);
                    if (num < percentageOfBlockedCells)
                    {
                        generatedMatrix[row, col] = LabyrinthConstants.BLOCKED_CELL_CHAR;
                    }
                    else
                    {
                        generatedMatrix[row, col] = LabyrinthConstants.FREE_CELL_CHAR;
                    }

                }
            }
            generatedMatrix[this.player.CurrentPlayerPositionY, this.player.CurrentPlayerPositionX] = LabyrinthConstants.PLAYER_SIGN_CHAR;

            this.MakeAtLeastOneExitReachable(generatedMatrix);
            Console.WriteLine("Welcome to “Labirinth” game. Please try to escape. Use 'top' to view the top");
            Console.WriteLine("scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
            return generatedMatrix;
        }
        private void MakeAtLeastOneExitReachable(char[,] generatedMatrix)
        {
            Random rand = new Random();
            int pathX = LabyrinthConstants.PLAYER_START_POSITION_X;
            int pathY = LabyrinthConstants.PLAYER_START_POSITION_Y;
            int[] dirX = { 0, 0, 1, -1 };
            int[] dirY = { 1, -1, 0, 0 };
            int numberOfDirections = 4;
            int maximumTimesToChangeAfter = 2;

            while (this.IsGameOver(pathX, pathY) == false)
            {
                int num = rand.Next(0, numberOfDirections);
                int times = rand.Next(0, maximumTimesToChangeAfter);

                for (int d = 0; d < times; d++)
                {
                    if (pathX + dirX[num] >= 0 && pathX + dirX[num] < LabyrinthConstants.LABYRINTH_SIZE && pathY + dirY[num] >= 0 &&
                        pathY + dirY[num] < LabyrinthConstants.LABYRINTH_SIZE)
                    {
                        pathX += dirX[num];

                        pathY += dirY[num];
                        if (generatedMatrix[pathY, pathX] == LabyrinthConstants.PLAYER_SIGN_CHAR)
                        {
                            continue;
                        }
                        generatedMatrix[pathY, pathX] = LabyrinthConstants.FREE_CELL_CHAR;
                    }
                }
            }
        }

        public virtual bool IsGameOver(int playerPositionX, int playerPositionY)
        {
            if ((playerPositionX > 0 && playerPositionX < LabyrinthConstants.LABYRINTH_SIZE - 1) &&
                (playerPositionY > 0 && playerPositionY < LabyrinthConstants.LABYRINTH_SIZE - 1))
            {
                return false;
            }

            return true;
        }
    }
}
