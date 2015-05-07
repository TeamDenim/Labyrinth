namespace Labyrinth.Common.Player
{
    using System;
    using Labyrinth.Common.Constants;
    using Labyrinth.Common.Interfaces;

    /// <summary>
    /// Internal class- process the game player.
    /// </summary>
    public class Player : IPlayer
    {
        // TODO: Should the player take the labyrinth as a param?

        /// <summary>
        /// The current position of the player along the horizontal axis.
        /// </summary>
        private int currentPlayerPositionX;

        /// <summary>
        /// The current position of the player along the vertical axis.
        /// </summary>
        private int currentPlayerPositionY;

        /// <summary>
        /// The labyrinth as a char matrix.
        /// </summary>
        private char[,] labyrinth;

        /// <summary>
        ///Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="labyrinth" type="char[,]">Labyrinth</param>
        public Player(char[,] labyrinth)
        {
            this.CurrentPlayerPositionX = LabyrinthConstants.PLAYER_START_POSITION_X;
            this.CurrentPlayerPositionY = LabyrinthConstants.PLAYER_START_POSITION_Y;
            this.labyrinth = labyrinth;
        }

        /// <summary>
        /// Gets and sets the player's current position along the horizontal axis.
        /// </summary>
        public int CurrentPlayerPositionX 
        {
            get { return this.currentPlayerPositionX; }
            set
            {
                this.currentPlayerPositionX = value;
            } 
        }

        /// <summary>
        /// Gets and sets the player's current position along the vertical axis.
        /// </summary>
        public int CurrentPlayerPositionY 
        {
            get { return this.currentPlayerPositionY; }
            set
            {
                this.currentPlayerPositionY = value;
            }
        }

        /// <summary>
        /// Gets and sets the labyrinth.
        /// </summary>
        public char[,] CurrentLabyrinth
        {
            get { return this.labyrinth; }
            set
            {
                this.labyrinth = value;
            }
        }

        /// <summary>
        /// Handles player movement inthe labyrinth.
        /// </summary>
        /// <param name="dirX" type="integer">Horizontal direction of the movement.</param>
        /// <param name="dirY" type="integer">Vertical direction of the movement.</param>
        public virtual void Move(int dirX, int dirY)
        {
            if (this.IsMoveValid(this.currentPlayerPositionX + dirX, this.currentPlayerPositionY + dirY) )
            {
                if (IsBlockedCell( dirX, dirY))
                {
                    Console.WriteLine(Messages.INVALID_MOVE_MESSAGE);
                }
                else
                {
                    DrawPlayer(dirX, dirY);
                    DrawFreeCell();
                    ChangePlayerPositon(dirX, dirY);
                }
            }
        }

        /// <summary>
        /// Changes the player's position along the X and Y axis.
        /// </summary>
        /// <param name="dirX" type="integer">Horizontal direction of the movement.</param>
        /// <param name="dirY" type="integer">Vertical direction of the movement.</param>
        private void ChangePlayerPositon(int dirX, int dirY)
        {
            this.currentPlayerPositionY += dirY;
            this.currentPlayerPositionX += dirX;
        }

        /// <summary>
        /// Checks if player can move through the adjacent cell.
        /// </summary>
        /// <param name="dirX" type="integer">Horizontal direction of the movement.</param>
        /// <param name="dirY" type="integer">Vertical direction of the movement.</param>
        /// <returns>bool</returns>
        private bool IsBlockedCell(int dirX, int dirY)
        {
            return this.labyrinth[this.currentPlayerPositionY + dirY, this.currentPlayerPositionX + dirX] ==
                   LabyrinthConstants.BLOCKED_CELL_CHAR;
        }

        /// <summary>
        /// Checks if movement is inside the labyrinth.
        /// </summary>
        /// <param name="x" type="ïnteger"></param>
        /// <param name="y" type="ïnteger"></param>
        /// <returns>bool</returns>
        public virtual bool IsMoveValid(int x, int y)
        {
            return x >= 0 && x <= LabyrinthConstants.LABYRINTH_SIZE - 1 
                && y >= 0 && y <= LabyrinthConstants.LABYRINTH_SIZE - 1;
        }

        /// <summary>
        /// Draws player.
        /// </summary>
        /// <param name="dirX" type="integer">Horizontal direction of the movement.</param>
        /// <param name="dirY" type="integer">Vertical direction of the movement.</param>
        /// <returns>char</returns>
        public char DrawPlayer(int dirX, int dirY)
        {
            return this.labyrinth[this.currentPlayerPositionY + dirY, this.currentPlayerPositionX + dirX] = LabyrinthConstants.PLAYER_SIGN_CHAR;
        }

        /// <summary>
        /// Draws cells that the player can pass through.
        /// </summary>
        /// <returns>char</returns>
        public char DrawFreeCell()
        {
            return this.labyrinth[this.currentPlayerPositionY, this.currentPlayerPositionX] = LabyrinthConstants.FREE_CELL_CHAR;
        }
    }
}
