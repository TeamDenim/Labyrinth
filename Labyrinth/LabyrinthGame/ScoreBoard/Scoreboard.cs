﻿namespace Labyrinth.Common
{
    using Wintellect.PowerCollections;
    using System;
    using Labyrinth.Common.Interfaces;

    public class Scoreboard: IScoreBoard
    {
        private OrderedMultiDictionary<int, string> scoreBoard;

        public Scoreboard()
        {
            this.scoreBoard = new OrderedMultiDictionary<int, string>(true);
        }
        public virtual void UpdateScoreBoard(int currentNumberOfMoves)
        {
            string userName = string.Empty;

            if (this.scoreBoard.Count < 5)
            {
                while (userName == string.Empty)
                {
                    Console.WriteLine(Messages.ENTER_NAME_MESSAGE);
                    userName = Console.ReadLine();
                }
                this.scoreBoard.Add(currentNumberOfMoves, userName);
            }
            else
            {
                int worstScore = this.GetWorstScore();
                if (currentNumberOfMoves <= worstScore)
                {
                    if (this.scoreBoard.ContainsKey(currentNumberOfMoves) == false)
                    {
                        this.scoreBoard.Remove(worstScore);
                    }
                    while (userName == string.Empty)
                    {
                        Console.WriteLine(Messages.ENTER_NAME_MESSAGE);
                        userName = Console.ReadLine();
                    }
                    this.scoreBoard.Add(currentNumberOfMoves, userName);
                }
            }
        }

        public virtual int GetWorstScore()
        {

            int worstScore = 0;
            foreach (var score in this.scoreBoard.Keys)
            {
                worstScore = score;
            }

            return worstScore;
        }

        public virtual void PrintScore()
        {
            int counter = 1;

            if (this.scoreBoard.Count == 0)
            {
                Console.WriteLine(Messages.SCOREBOARD_EMPTY_MESSAGE);

            }
            else
            {
                foreach (var score in this.scoreBoard)
                {
                    var foundScore = this.scoreBoard[score.Key];

                    foreach (var equalScore in foundScore)
                    {
                        Console.WriteLine(Messages.SCOREBOARD_DISPLAY_FORMAT, counter, equalScore, score.Key);

                    }
                    counter++;
                }
            }


            Console.WriteLine();
        }

    }
}
