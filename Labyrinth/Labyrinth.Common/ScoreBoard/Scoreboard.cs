namespace Labyrinth.Common.ScoreBoard
{
    using System;
    using Labyrinth.Common.Constants;
    using Labyrinth.Common.Interfaces;
    using Wintellect.PowerCollections;

    /// <summary>
    /// Scoreboard class inherits IScoreboard.
    /// Processes the game's high scores.
    /// </summary>
    public class Scoreboard: IScoreboard
    {
        /// <summary>
        /// Number of scores to be shown on the scoreboard.
        /// </summary>
        private const int NUMBER_OF_TOP_SCORES = 5;

        /// <summary>
        /// Ordered dictionary holding data value pair: score/name.
        /// </summary>
        private readonly OrderedMultiDictionary<int, string> scoreBoard;

        /// <summary>
        /// Initializes a new instance of the <see cref="Scoreboard"/> class.
        /// </summary>
        public Scoreboard()
        {
            this.scoreBoard = new OrderedMultiDictionary<int, string>(true);
        }

        /// <summary>
        /// Fills and updates the scoreboard.
        /// </summary>
        /// <param name="currentNumberOfMoves" type="integer">Takes the number of moves of the current player.</param>
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

        /// <summary>
        /// Updates the top five players by the number of moves they made during the game.
        /// </summary>
        /// <param name="currentNumberOfMoves" type="integer">Takes the number of moves of the current player.</param>
        /// <param name="userName" type="string">Takes the name of the current player.</param>
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

        /// <summary>
        /// Adds players to the scoreboard.
        /// </summary>
        /// <param name="currentNumberOfMoves" type="integer">Takes the number of moves of the current player.</param>
        /// <param name="userName" type="string">Takes the name of the current player.</param>
        private void AddPlayerToScoreboard(int currentNumberOfMoves, string userName)
        {
            while (userName == string.Empty)
            {
                Console.WriteLine(Messages.ENTER_NAME_MESSAGE);
                userName = Console.ReadLine();
            }
            this.scoreBoard.Add(currentNumberOfMoves, userName);
        }

        /// <summary>
        /// Gets the worst score from the current game only.
        /// </summary>
        /// <returns>Worst score.</returns>
        public virtual int GetWorstScore()
        {
            var worstScore = 0;
            foreach (var score in this.scoreBoard.Keys)
            {
                worstScore = score;
            }

            return worstScore;
        }

        /// <summary>
        /// Returns a string of formatted highScores.
        /// Prints them to the console.
        /// </summary>
        /// <returns>String of high scores.</returns>
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

                        // TODO: Separate the printing of the output!

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
