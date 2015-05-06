namespace Labyrinth.Common.Interfaces
{
    /// <summary>
    /// Defines an IScoreboard interface.
    /// </summary>
    public interface IScoreboard
    {
        /// <summary>
        /// Fills and updates the scoreboard.
        /// </summary>
        /// <param name="currentNumberOfMoves" type="integer">Takes the number of moves of the current player.</param>
        void UpdateScoreBoard(int currentNumberOfMoves);

        /// <summary>
        /// Gets the worst score from the current game only.
        /// </summary>
        /// <returns>Worst score.</returns>
        int GetLastScore();

        /// <summary>
        /// Returns a string of formatted highScores.
        /// Prints them to the console.
        /// </summary>
        /// <returns>String of high scores.</returns>
        string PrintScore();
    }
}
