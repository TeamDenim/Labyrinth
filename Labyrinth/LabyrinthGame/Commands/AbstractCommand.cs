namespace Labyrinth.Common.Commands
{
    using System.Collections.Generic;
    using Labyrinth.Common.Interfaces;

    public abstract class AbstractCommand : ICommand
    {
        public readonly List<string> Data = new List<string>();

        public abstract void Execute();
    }
}
