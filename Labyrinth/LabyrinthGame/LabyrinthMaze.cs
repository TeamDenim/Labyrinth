using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

namespace Labyrinth.Common
{
    // tuka polzvame edna biblioteka - PowerCollections - moze da ya namerite v gugal - ima sortiran re4nik, mnogo udobno za klasaciata
    class LabyrinthMaze
    {
        private const int LABYRINTH_SIZE = 7;
        private const int PLAYER_START_POSITION_X = 3;
        private const int PLAYER_START_POSITION_Y = 3;
        private const int MINIMUM_PERCENTAGE_OF_BLOCKED_CELLS = 30;
        private const int MAXIMUM_PERCENTAGE_OF_BLOCKED_CELLS = 50;

        const char BLOCKED_CELL_CHAR = 'X';
        const char FREE_CELL_CHAR = '-';
        const char PLAYER_SIGN_CHAR = '*';

        private int currentPlayerPositionX;
        private int currentPlayerPositionY;

        private char[,] matrix;
        private OrderedMultiDictionary<int, string> scoreBoard;


        public LabyrinthMaze()
        {
            this.currentPlayerPositionX = PLAYER_START_POSITION_X;
            this.currentPlayerPositionY = PLAYER_START_POSITION_Y;
            this.matrix = this.GenerateMatrix();
            this.scoreBoard = new OrderedMultiDictionary<int, string>(true);
        }

        private void Move(int dirX, int dirY)
        {

            if (this.IsMoveValid(this.currentPlayerPositionX + dirX, this.currentPlayerPositionY + dirY) == false)
            {
                return;
            }

            if (this.matrix[currentPlayerPositionY + dirY, currentPlayerPositionX + dirX] == BLOCKED_CELL_CHAR)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                return;
            }
            else
            {
                this.matrix[this.currentPlayerPositionY, this.currentPlayerPositionX] = FREE_CELL_CHAR;
                this.matrix[this.currentPlayerPositionY + dirY, this.currentPlayerPositionX + dirX] = PLAYER_SIGN_CHAR;
                this.currentPlayerPositionY += dirY;
                this.currentPlayerPositionX += dirX;
                return;
            }
        }
        private bool IsMoveValid(int x, int y)
        {
            if (x < 0 || x > LABYRINTH_SIZE - 1 || y < 0 || y > LABYRINTH_SIZE - 1)
            {
                return false;
            }

            return true;
        }
        private void PrintLabirynth()
        {
            for (int row = 0; row < LABYRINTH_SIZE; row++)
            {
                for (int col = 0; col < LABYRINTH_SIZE; col++)
                {
                    Console.Write("{0,2}", this.matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
        private char[,] GenerateMatrix()
        {
            char[,] generatedMatrix = new char[LABYRINTH_SIZE, LABYRINTH_SIZE];
            Random rand = new Random();
            int percentageOfBlockedCells = rand.Next(MINIMUM_PERCENTAGE_OF_BLOCKED_CELLS, MAXIMUM_PERCENTAGE_OF_BLOCKED_CELLS);

            for (int row = 0; row < LABYRINTH_SIZE; row++)
            {
                for (int col = 0; col < LABYRINTH_SIZE; col++)
                {
                    int num = rand.Next(0, 100);
                    if (num < percentageOfBlockedCells)
                    {
                        generatedMatrix[row, col] = BLOCKED_CELL_CHAR;
                    }
                    else
                    {
                        generatedMatrix[row, col] = FREE_CELL_CHAR;
                    }

                }
            }
            generatedMatrix[currentPlayerPositionY, currentPlayerPositionX] = PLAYER_SIGN_CHAR;

            this.MakeAtLeastOneExitReachable(generatedMatrix);
            Console.WriteLine("Welcome to “Labirinth” game. Please try to escape. Use 'top' to view the top");
            Console.WriteLine("scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
            return generatedMatrix;
        }
        private void MakeAtLeastOneExitReachable(char[,] generatedMatrix)
        {
            Random rand = new Random();
            int pathX = PLAYER_START_POSITION_X;
            int pathY = PLAYER_START_POSITION_Y;
            int[] dirX = { 0, 0, 1, -1 };
            int[] dirY = { 1, -1, 0, 0 };
            int numberOfDirections = 4;
            int maximumTimesToChangeAfter = 2;

            while (this.IsGameOver(pathX, pathY) == false)
            {
                int num = rand.Next(0, numberOfDirections);
                int times = rand.Next(0, maximumTimesToChangeAfter);

                for (int d = 0; d < times; d++)
                {
                    if (pathX + dirX[num] >= 0 && pathX + dirX[num] < LABYRINTH_SIZE && pathY + dirY[num] >= 0 &&
                        pathY + dirY[num] < LABYRINTH_SIZE)
                    {


                        pathX += dirX[num];



                        pathY += dirY[num];
                        if (generatedMatrix[pathY, pathX] == PLAYER_SIGN_CHAR)
                        {
                            continue;
                        }
                        generatedMatrix[pathY, pathX] = FREE_CELL_CHAR;
                    }
                }
            }
        }

        private bool IsGameOver(int playerPositionX, int playerPositionY)
        {
            if ((playerPositionX > 0 && playerPositionX < LABYRINTH_SIZE - 1) &&
                (playerPositionY > 0 && playerPositionY < LABYRINTH_SIZE - 1))
            {
                return false;
            }

            return true;
        }

        private int GetWorstScore()
        {


            int worstScore = 0;
            foreach (var score in this.scoreBoard.Keys)
            {
                worstScore = score;
            }

            return worstScore;
        }

        private void PrintScore()
        {
            int counter = 1;

            if (this.scoreBoard.Count == 0)
            {
                Console.WriteLine("The scoreboard is empty.");



            }
            else
            {
                foreach (var score in this.scoreBoard)
                {
                    var foundScore = this.scoreBoard[score.Key];

                    foreach (var equalScore in foundScore)
                    {
                        Console.WriteLine("{0}. {1} --> {2}", counter, equalScore, score.Key);

                    }
                    counter++;
                }
            }


            Console.WriteLine();
        }

        public void PlayGame()
        {
            string command = string.Empty;
            int movesCounter = 0;
            while (command.Equals("EXIT") == false)
            {
                PrintLabirynth();
                string currentLine = string.Empty;

                if (this.IsGameOver(this.currentPlayerPositionX, this.currentPlayerPositionY))
                {
                    Console.WriteLine("Congratulations! You've exited the labirynth in {0} moves.", movesCounter);

                    this.UpdateScoreBoard(movesCounter);
                    this.PrintScore();
                    movesCounter = 0;
                    currentLine = "RESTART";
                }
                else
                {
                    Console.Write("Enter your move (L=left, R-right, U=up, D=down):");
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
                case "L":
                    {
                        movesCounter++;
                        Move(-1, 0);
                        break;
                    }
                case "R":
                    {
                        movesCounter++;
                        Move(1, 0);
                        break;
                    }
                case "U":
                    {
                        movesCounter++;
                        Move(0, -1);
                        break;
                    }
                case "D":
                    {
                        movesCounter++;
                        Move(0, 1);
                        break;
                    }
                case "RESTART":
                    {
                        this.currentPlayerPositionX = PLAYER_START_POSITION_X;
                        this.currentPlayerPositionY = PLAYER_START_POSITION_Y;
                        this.matrix = this.GenerateMatrix();

                        break;
                    }
                case "TOP":
                    {
                        this.PrintScore();
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
        private void UpdateScoreBoard(int currentNumberOfMoves)
        {
            string userName = string.Empty;

            if (this.scoreBoard.Count < 5)
            {
                while (userName == string.Empty)
                {
                    Console.WriteLine("**Please put down your name:**");
                    userName = Console.ReadLine();
                }
                this.scoreBoard.Add(currentNumberOfMoves, userName);
            }
            else
            {
                int worstScore = this.GetWorstScore();
                if (currentNumberOfMoves <= worstScore)
                {
                    if (this.scoreBoard.ContainsKey(currentNumberOfMoves) == false)
                    {
                        this.scoreBoard.Remove(worstScore);
                    }
                    while (userName == string.Empty)
                    {
                        Console.WriteLine("**Please put down your name:**");
                        userName = Console.ReadLine();
                    }
                    this.scoreBoard.Add(currentNumberOfMoves, userName);
                }
            }
        }
    }
}
