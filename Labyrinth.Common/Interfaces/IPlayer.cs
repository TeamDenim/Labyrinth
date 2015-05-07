namespace Labyrinth.Common.Interfaces
{
    /// <summary>
    /// Defines an IPlayer interface.
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// Handles player movement inthe labyrinth.
        /// </summary>
        /// <param name="dirX" type="integer">Horizontal direction of the movement.</param>
        /// <param name="dirY" type="integer">Vertical direction of the movement.</param>
        void Move(int dirX, int dirY);

        /// <summary>
        /// Checks if movement is inside the labyrinth.
        /// </summary>
        /// <param name="x" type="ïnteger"></param>
        /// <param name="y" type="ïnteger"></param>
        /// <returns>bool</returns>
        bool IsMoveValid(int x, int y);

        /// <summary>
        /// Gets and sets the player's current position along the horizontal axis.
        /// </summary>
        int CurrentPlayerPositionX { get; set; }

        /// <summary>
        /// Gets and sets the player's current position along the vertical axis.
        /// </summary>
        int CurrentPlayerPositionY { get; set; }

        /// <summary>
        /// Gets and sets the labyrinth.
        /// </summary>
        char[,] CurrentLabyrinth { get; set; }
    }
}
