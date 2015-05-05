namespace Labyrinth.Common
{
    using Labyrinth.Common.Interfaces;
    using Labyrinth.Common.LabyrinthTools;
    using System;

    public class LabryrinthEngine : IEngine
    {
        private IPlayer player;
        private ILabyrinthTools labyrinthTools;
        private char[,] labyrinth;
        private IScoreBoard scoreBoard;

        public LabryrinthEngine()
        {
            this.labyrinthTools = new LabyrinthTools.LabyrinthTools();
            this.labyrinth = this.labyrinthTools.GenerateLabyrinth();
            this.player = new Player(this.labyrinth);
            this.scoreBoard = new Scoreboard();
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
                if (currentLine == string.Empty)
                {
                    continue;
                }

                command = currentLine.ToUpper();
                this.ExecuteCommand(command, ref movesCounter);
            }
        }
        private void ExecuteCommand(string command, ref int movesCounter)
        {
            switch (command.ToUpper())
            {
                case "A":
                    {
                        movesCounter++;
                        this.player.Move(-1, 0);
                        break;
                    }
                case "D":
                    {
                        movesCounter++;
                        this.player.Move(1, 0);
                        break;
                    }
                case "W":
                    {
                        movesCounter++;
                        this.player.Move(0, -1);
                        break;
                    }
                case "S":
                    {
                        movesCounter++;
                        this.player.Move(0, 1);
                        break;
                    }
                case "RESTART":
                    {
                        this.player.CurrentPlayerPositionX = LabyrinthConstants.PLAYER_START_POSITION_X;
                        this.player.CurrentPlayerPositionY = LabyrinthConstants.PLAYER_START_POSITION_Y;
                        this.player.CurrentLabyrinth = this.labyrinthTools.GenerateLabyrinth();

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
                        Console.WriteLine(Messages.INVALID_INPUT);
                        break;
                    }
            }
        }
    }
}
