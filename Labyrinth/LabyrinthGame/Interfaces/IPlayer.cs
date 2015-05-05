namespace Labyrinth.Common.Interfaces
{
    public interface IPlayer
    {
        void Move(int dirX, int dirY);
        bool IsMoveValid(int x, int y);
        int CurrentPlayerPlayerPositionX { get; set; }
        int CurrentPlayerPlayerPositionY { get; set; }
    }
}
