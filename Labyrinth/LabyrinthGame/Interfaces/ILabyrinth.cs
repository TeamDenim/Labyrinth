namespace Labyrinth.Common.Interfaces
{
    interface ILabyrinthTools
    {
        char[,] Labyrinth { get; }
        char[,] GenerateLabyrinth();
        bool IsGameOver(int playerPositionX, int playerPositionY);
        void PrintLabirynth(IPlayer player);
    }
}
