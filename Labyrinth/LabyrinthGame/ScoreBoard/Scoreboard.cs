namespace Labyrinth.Common.ScoreBoard
{
    using System;
    using Labyrinth.Common.Constants;
    using Labyrinth.Common.Interfaces;
    using Wintellect.PowerCollections;

    public class Scoreboard: IScoreBoard
    {
        private const int NUMBER_OF_TOP_SCORES = 5;
        private readonly OrderedMultiDictionary<int, string> scoreBoard;

        public Scoreboard()
        {
            this.scoreBoard = new OrderedMultiDictionary<int, string>(true);
        }

        public virtual void UpdateScoreBoard(int currentNumberOfMoves)
        {
            var userName = string.Empty;

            if (this.scoreBoard.Count < NUMBER_OF_TOP_SCORES)
            {
                AddPlayerToScoreboard(currentNumberOfMoves, userName);
            }
            else
            {
                UpdatePlayersOnScoreboard(currentNumberOfMoves, userName);
            }
        }

        private void UpdatePlayersOnScoreboard(int currentNumberOfMoves, string userName)
        {
            var worstScore = this.GetWorstScore();
            if (currentNumberOfMoves <= worstScore)
            {
                if (this.scoreBoard.ContainsKey(currentNumberOfMoves) == false)
                {
                    this.scoreBoard.Remove(worstScore);
                }
                AddPlayerToScoreboard(currentNumberOfMoves, userName);
            }
        }

        private void AddPlayerToScoreboard(int currentNumberOfMoves, string userName)
        {
            while (userName == string.Empty)
            {
                Console.WriteLine(Messages.ENTER_NAME_MESSAGE);
                userName = Console.ReadLine();
            }
            this.scoreBoard.Add(currentNumberOfMoves, userName);
        }

        public virtual int GetWorstScore()
        {
            var worstScore = 0;
            foreach (var score in this.scoreBoard.Keys)
            {
                worstScore = score;
            }

            return worstScore;
        }

        public virtual string PrintScore()
        {
            var counter = 1;
            var output = string.Empty;

            if (this.scoreBoard.Count != 0)
            {
                foreach (var score in this.scoreBoard)
                {
                    var foundScore = this.scoreBoard[score.Key];

                    foreach (var equalScore in foundScore)
                    {
                        output = string.Format(Messages.SCOREBOARD_DISPLAY_FORMAT, counter, equalScore, score.Key);
                        Console.WriteLine(output);
                    }

                    counter++;
                }
            }
            else
            {
                output = string.Format(Messages.SCOREBOARD_EMPTY_MESSAGE);
            }

            return output;
        }
    }
}
