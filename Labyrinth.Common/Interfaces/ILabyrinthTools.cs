namespace Labyrinth.Common.Interfaces
{
    /// <summary>
    /// Defines an ILabyrinthTools interface.
    /// </summary>
    interface ILabyrinthTools
    {
        // TODO: Add XML documentation to this interface and the class that inherits it.

        char[,] Labyrinth { get; }

        char[,] GenerateLabyrinth();

        bool IsGameOver(int playerPositionX, int playerPositionY);

        void PrintLabirynth(IPlayer player);
    }
}
