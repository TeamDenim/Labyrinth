namespace Labyrinth.Common
{
    using Labyrinth.Common.Interfaces;
    using System;

    public class Player : IPlayer
    {
        private int currentPlayerPositionX;
        private int currentPlayerPositionY;
        private char[,] labyrinth;

        public Player(int startPlayerPositionX, int startPlayerPositionY, char[,] labyrinth)
        {
            this.CurrentPlayerPlayerPositionX = startPlayerPositionX;
            this.CurrentPlayerPlayerPositionY = this.currentPlayerPositionX;
            this.labyrinth = labyrinth;
        }

        public int CurrentPlayerPlayerPositionX 
        {
            get { return this.currentPlayerPositionX; }
            set
            {
                this.currentPlayerPositionX = value;
            } 
        }
        public int CurrentPlayerPlayerPositionY 
        {
            get { return this.currentPlayerPositionY; }
            set
            {
                this.CurrentPlayerPlayerPositionY = value;
            }
        }


        public virtual void Move(int dirX, int dirY)
        {
            if (this.IsMoveValid(this.currentPlayerPositionX + dirX, this.currentPlayerPositionY + dirY) == false)
            {
                return;
            }

            if (this.labyrinth[currentPlayerPositionY + dirY, currentPlayerPositionX + dirX] == LabyrinthConstants.BLOCKED_CELL_CHAR)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                return;
            }
            else
            {
                this.labyrinth[this.currentPlayerPositionY, this.currentPlayerPositionX] = LabyrinthConstants.FREE_CELL_CHAR;
                this.labyrinth[this.currentPlayerPositionY + dirY, this.currentPlayerPositionX + dirX] = LabyrinthConstants.PLAYER_SIGN_CHAR;
                this.currentPlayerPositionY += dirY;
                this.currentPlayerPositionX += dirX;
                return;
            }
        }

        public virtual bool IsMoveValid(int x, int y)
        {
            if (x < 0 || x > LabyrinthConstants.LABYRINTH_SIZE - 1 || y < 0 || y > LabyrinthConstants.LABYRINTH_SIZE - 1)
            {
                return false;
            }

            return true;
        }
    }
}
