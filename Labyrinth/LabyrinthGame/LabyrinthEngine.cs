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

        public void Run()
        {
            string command = string.Empty;
            int movesCounter = 0;
            while (command.Equals("EXIT") == false)
            {
                PrintLabirynth();
                string currentLine = string.Empty;

                if (this.labyrinthTools.IsGameOver(this.player.CurrentPlayerPositionX, this.player.CurrentPlayerPositionY))
                {
                    Console.WriteLine("Congratulations! You've exited the labirynth in {0} moves.", movesCounter);

                    this.scoreBoard.UpdateScoreBoard(movesCounter);
                    this.scoreBoard.PrintScore();
                    movesCounter = 0;
                    currentLine = "RESTART";
                }
                else
                {
                    Console.Write("Enter your move (A=left, D-right, W=up, S=down):");
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

        private void PrintLabirynth()
        {
            for (int row = 0; row < LabyrinthConstants.LABYRINTH_SIZE; row++)
            {
                for (int col = 0; col < LabyrinthConstants.LABYRINTH_SIZE; col++)
                {
                    Console.Write("{0,2}", this.player.CurrentLabyrinth[row, col]);
                }
                Console.WriteLine();
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
                        Console.WriteLine("Invalid input!");
                        Console.WriteLine("**Press a key to continue**");
                        Console.ReadKey();
                        break;
                    }
            }
        }
    }
}
