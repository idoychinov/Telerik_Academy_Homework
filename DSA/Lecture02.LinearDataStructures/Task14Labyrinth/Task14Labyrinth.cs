namespace Task14Labyrinth
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// * We are given a labyrinth of size N x N. Some of its cells are empty (0) and some are full (x). 
    /// We can move from an empty cell to another empty cell if they share common wall. Given a starting position (*) calculate and 
    /// fill in the array the minimal distance from this position to any other cell in the array. Use "u" for all unreachable cells.
    /// </summary>
    public class Task14Labyrinth
    {
        public static void Main()
        {
            const int N = 6;
            string[,] labyrinth = new string[N, N] 
            {
            { "0", "0", "0", "x", "0", "x" },
            { "0", "x", "0", "x", "0", "x" },
            { "0", "*", "x", "0", "x", "0" },
            { "0", "x", "0", "0", "0", "0" },
            { "0", "0", "0", "x", "x", "0" },
            { "0", "0", "0", "x", "0", "x" },
            };

            var startingPosition = FindStartingPosition(N, labyrinth);
            FillDistance(N, labyrinth, startingPosition);

            PrintLabyrinth(N, labyrinth);
        }

        private static void FillDistance(int n, string[,] labyrinth, Position startingPosition)
        {
            Position[] directions = new Position[]
            {
                new Position(-1, 0),
                new Position(0, -1),
                new Position(1, 0),
                new Position(0, 1)
            };
            Queue<Position> positions = new Queue<Position>();
            positions.Enqueue(startingPosition);
            while (positions.Count > 0)
            {
                var currentPosition = positions.Dequeue();
                for (var i = 0; i < 4; i++)
                {
                    int newX = currentPosition.X + directions[i].X;
                    int newY = currentPosition.Y + directions[i].Y;
                    bool isInLabyrintRange = newX >= 0 && newX < n && newY >= 0 && newY < n;
                    if (isInLabyrintRange && labyrinth[newX, newY] == "0")
                    {
                        string currentSymbol = labyrinth[currentPosition.X, currentPosition.Y];
                        int currentDistance;
                        if (currentSymbol == "*")
                        {
                            currentDistance = 0;
                        }
                        else
                        {
                            currentDistance = int.Parse(currentSymbol);
                        }

                        labyrinth[newX, newY] = (currentDistance + 1).ToString();
                        positions.Enqueue(new Position(newX, newY));
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (labyrinth[i, j] == "0")
                    {
                        labyrinth[i, j] = "u";
                    }
                }
            }
        }

        private static void PrintLabyrinth(int n, string[,] labyrinth)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0,2} ", labyrinth[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static Position FindStartingPosition(int n, string[,] labyrinth)
        {
            int startX = 0, startY = 0;
            bool found = false;

            for (int i = 0; i < n; i++)
            {
                if (found)
                {
                    break;
                }

                for (int j = 0; j < n; j++)
                {
                    if (labyrinth[i, j] == "*")
                    {
                        startX = i;
                        startY = j;
                        found = true;
                        break;
                    }
                }
            }

            if (found)
            {
                return new Position(startX, startY);
            }
            else
            {
                throw new InvalidOperationException("No starting position found in array");
            }
        }
    }
}
