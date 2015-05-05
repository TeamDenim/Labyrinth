namespace Labyrinth.Common.Interfaces
{
    interface IScoreBoard
    {
        void UpdateScoreBoard(int currentNumberOfMoves);

        int GetWorstScore();

        string PrintScore();
    }
}
