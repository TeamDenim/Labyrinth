using Labyrinth.Common.Constants;

namespace Labyrinth.Common.Commands
{
    using Labyrinth.Common.Interfaces;
    using LabyrinthTools;

    public class CommandExecuter
    {
        private IPlayer player;
        private ILabyrinthTools labyrinthTools;

        public CommandExecuter(IPlayer player)
        {
            this.player = player;
            this.labyrinthTools = new LabyrinthTools();
        }

        public virtual void MoveLeft()
        {
            this.player.Move(-1, 0);
        }

        public virtual void MoveRight()
        {
            this.player.Move(1, 0);
        }

        public virtual void MoveUp()
        {
            this.player.Move(0, -1);
        }

        public virtual void MoveDown()
        {
            this.player.Move(0, 1);
        }

        public virtual void Restart()
        {
            this.player.CurrentPlayerPositionX = LabyrinthConstants.PLAYER_START_POSITION_X;
            this.player.CurrentPlayerPositionY = LabyrinthConstants.PLAYER_START_POSITION_Y;
            this.player.CurrentLabyrinth = this.labyrinthTools.GenerateLabyrinth();
        }

    }
}
