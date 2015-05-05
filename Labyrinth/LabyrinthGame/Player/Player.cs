﻿namespace Labyrinth.Common
{
    using Labyrinth.Common.Interfaces;
    using System;

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
            if (this.IsMoveValid(this.currentPlayerPositionX + dirX, this.currentPlayerPositionY + dirY) == false)
            {
                return;
            }



            if (this.labyrinth[this.currentPlayerPositionY + dirY, this.currentPlayerPositionX + dirX] == LabyrinthConstants.BLOCKED_CELL_CHAR)
            {
                Console.WriteLine("\n Invalid Move! - Please enter valid move! \n");
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