namespace Labyrinth.Common.Player
{
    using System;
    using Labyrinth.Common.Constants;
    using Labyrinth.Common.Interfaces;

    public class Player : IPlayer
    {
        private int currentPlayerPositionX;
        private int currentPlayerPositionY;
        private char[,] labyrinth;

        public Player(char[,] labyrinth)
        {
            this.CurrentPlayerPositionX = LabyrinthConstants.PLAYER_START_POSITION_X;
            this.CurrentPlayerPositionY = LabyrinthConstants.PLAYER_START_POSITION_Y;
            this.labyrinth = labyrinth;
        }

        public int CurrentPlayerPositionX 
        {
            get { return this.currentPlayerPositionX; }
            set
            {
                this.currentPlayerPositionX = value;
            } 
        }

        public int CurrentPlayerPositionY 
        {
            get { return this.currentPlayerPositionY; }
            set
            {
                this.currentPlayerPositionY = value;
            }
        }

        public char[,] CurrentLabyrinth
        {
            get { return this.labyrinth; }
            set
            {
                this.labyrinth = value;
            }
        }

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

        private void ChangePlayerPositon(int dirX, int dirY)
        {
            this.currentPlayerPositionY += dirY;
            this.currentPlayerPositionX += dirX;
        }

        private bool IsBlockedCell(int dirX, int dirY)
        {
            return this.labyrinth[this.currentPlayerPositionY + dirY, this.currentPlayerPositionX + dirX] ==
                   LabyrinthConstants.BLOCKED_CELL_CHAR;
        }

        public virtual bool IsMoveValid(int x, int y)
        {
            return x >= 0 && x <= LabyrinthConstants.LABYRINTH_SIZE - 1 
                && y >= 0 && y <= LabyrinthConstants.LABYRINTH_SIZE - 1;
        }

        public char DrawPlayer(int dirX, int dirY)
        {
            return this.labyrinth[this.currentPlayerPositionY + dirY, this.currentPlayerPositionX + dirX] = LabyrinthConstants.PLAYER_SIGN_CHAR;
        }

        public char DrawFreeCell()
        {
            return this.labyrinth[this.currentPlayerPositionY, this.currentPlayerPositionX] = LabyrinthConstants.FREE_CELL_CHAR;
        }
    }
}
