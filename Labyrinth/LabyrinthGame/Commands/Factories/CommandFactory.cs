namespace Labyrinth.Common.Commands.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Labyrinth.Common.Contracts;

    public static class CommandFactory
    {
        private const string CommandSuffix = "Command";

        public static ICommand Create(string commandInput)
        {
            var data = commandInput.Split(null);
            string commandName = data[0].ToLower();

            var commandClass = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass && t.Namespace == typeof(CommandFactory).Namespace)
                .Where(t => t.Name.EndsWith(CommandSuffix))
                .First(t => t.Name
                    .Replace(CommandSuffix, string.Empty)
                    .ToLower()
                    .Equals(commandName));

            var command = Activator.CreateInstance(commandClass) as AbstractCommand;

            foreach (var field in data)
            {
                command.Data.Add(field);
            }

            return (ICommand)command;
        }
    }
}
