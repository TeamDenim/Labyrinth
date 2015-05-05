namespace Labyrinth.Common
{
    using Labyrinth.Common.Commands;
    using Labyrinth.Common.Interfaces;
    using Labyrinth.Common.Constants;
    using Labyrinth.Common.ScoreBoard;
    using System;

    public class LabyrinthEngine : IEngine
    {
        private IPlayer player;
        private ILabyrinthTools labyrinthTools;
        private char[,] labyrinth;
        private IScoreBoard scoreBoard;
        private CommandExecuter commandExecuter;

        public LabyrinthEngine()
        {
            this.labyrinthTools = new LabyrinthTools.LabyrinthTools();
            this.labyrinth = this.labyrinthTools.GenerateLabyrinth();
            this.player = new Player.Player(this.labyrinth);
            this.scoreBoard = new Scoreboard();
            this.commandExecuter = new CommandExecuter(this.player);
        }

        public virtual void Run()
        {
            string command = string.Empty;
            int movesCounter = 0;
            while (command.Equals("EXIT") == false)
            {
                this.labyrinthTools.PrintLabirynth(this.player);
                string currentLine = string.Empty;

                if (this.labyrinthTools.IsGameOver(this.player.CurrentPlayerPositionX, this.player.CurrentPlayerPositionY))
                {
                    Console.WriteLine(Messages.WIN_MESSAGE, movesCounter);

                    this.scoreBoard.UpdateScoreBoard(movesCounter);
                    this.scoreBoard.PrintScore();
                    movesCounter = 0;
                    currentLine = "RESTART";
                }
                else
                {
                    Console.Write(Messages.MOVE_INSTRUCTION_MESSAGE);
                    currentLine = Console.ReadLine();
                }

                if (currentLine != null)
                {
                    command = currentLine.ToUpper();
                }
                this.ExecuteCommand(command, ref movesCounter);
            }
        }

        public virtual void ExecuteCommand(string command, ref int movesCounter)
        {
            switch (command)
            {
                case "A":
                    {
                        movesCounter++;
                        this.commandExecuter.MoveLeft();
                        break;
                    }
                case "D":
                    {
                        movesCounter++;
                        this.commandExecuter.MoveRight();
                        break;
                    }
                case "W":
                    {
                        movesCounter++;
                        this.commandExecuter.MoveUp();
                        break;
                    }
                case "S":
                    {
                        movesCounter++;
                        this.commandExecuter.MoveDown();
                        break;
                    }
                case "RESTART":
                    {
                        this.commandExecuter.Restart();
                        break;
                    }
                case "TOP":
                    {
                        this.scoreBoard.PrintScore();
                        break;
                    }
                case "EXIT":
                    {
                        break;
                    }
                default:
                    {
                        Console.Write(Messages.INVALID_INPUT);
                        break;
                    }
            }
        }
    }
}
