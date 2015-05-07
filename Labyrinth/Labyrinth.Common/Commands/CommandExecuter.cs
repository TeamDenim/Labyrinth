namespace Labyrinth.Common.Commands
{
    using Labyrinth.Common.Constants;
    using Labyrinth.Common.Interfaces;
    using LabyrinthTools;

    /// <summary>
    /// Executes user commands
    /// </summary>
    public class CommandExecuter
    {
        private IPlayer player;

        private ILabyrinthTools labyrinthTools;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandExecuter"/> class.
        /// </summary>
        /// <param name="player">Player</param>
        public CommandExecuter(IPlayer player)
        {
            this.player = player;
            this.labyrinthTools = new LabyrinthTools();
        }

        /// <summary>
        /// Makes the player change its coodrs by -1, 0
        /// </summary>
        public virtual void MoveLeft()
        {
            this.player.Move(-1, 0);
        }

        /// <summary>
        /// Makes the player change its coodrs by 1, 0
        /// </summary>
        public virtual void MoveRight()
        {
            this.player.Move(1, 0);
        }

        /// <summary>
        /// Makes the player change its coodrs by 0, -1
        /// </summary>
        public virtual void MoveUp()
        {
            this.player.Move(0, -1);
        }

        /// <summary>
        /// Makes the player change its coodrs by 0, 1
        /// </summary>
        public virtual void MoveDown()
        {
            this.player.Move(0, 1);
        }

        /// <summary>
        /// Restarts game
        /// </summary>
        public virtual void Restart()
        {
            this.player.CurrentPlayerPositionX = LabyrinthConstants.PLAYER_START_POSITION_X;
            this.player.CurrentPlayerPositionY = LabyrinthConstants.PLAYER_START_POSITION_Y;
            this.player.CurrentLabyrinth = this.labyrinthTools.GenerateLabyrinth();
        }
    }
}
