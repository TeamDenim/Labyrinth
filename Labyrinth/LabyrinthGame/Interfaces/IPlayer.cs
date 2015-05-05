namespace Labyrinth.Common.Interfaces
{
    public interface IPlayer
    {
        void Move(int dirX, int dirY);

        bool IsMoveValid(int x, int y);

        int CurrentPlayerPositionX { get; set; }

        int CurrentPlayerPositionY { get; set; }

        char[,] CurrentLabyrinth { get; set; }
    }
}
