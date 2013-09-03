using System;
using MyIO;

enum Direction { right, down, left, up };

class Spiral
{
    static void Main()
    {
        int N;
        Direction currentDirection = Direction.right;

        while (true)
        {
            MyIOClass.Input(out N, "Enter the number N: ");

            if ((N < 1) && (N >= 20))
            {
                Console.WriteLine("\nThe number N must be greater than 0 and less than 20");
            }
            else
            {
                break;
            }
        }
        int[,] array = new int[N, N];
        int count = 1, indexX = 0, indexY = 0, minIndexX = 0, minIndexY = 1, maxIndexX = N - 1, maxIndexY = N - 1;

        while (count <= N * N)
        {
            switch (currentDirection)
            {
                case Direction.right:
                    if (indexX <= maxIndexX)
                    {
                        array[indexY, indexX] = count;
                        count++;
                        indexX++;
                    }
                    else
                    {
                        currentDirection = Direction.down;
                        maxIndexX--;
                        indexX--;
                        indexY++;
                    }
                    break;
                case Direction.down:
                    if (indexY <= maxIndexY)
                    {
                        array[indexY, indexX] = count;
                        count++;
                        indexY++;
                    }
                    else
                    {
                        currentDirection = Direction.left;
                        maxIndexY--;
                        indexY--;
                        indexX--;
                    }
                    break;
                case Direction.left:
                    if (indexX >= minIndexX)
                    {
                        array[indexY, indexX] = count;
                        count++;
                        indexX--;
                    }
                    else
                    {
                        currentDirection = Direction.up;
                        minIndexX++;
                        indexX++;
                        indexY--;
                    }
                    break;
                case Direction.up:
                    if (indexY >= minIndexY)
                    {
                        array[indexY, indexX] = count;
                        count++;
                        indexY--;
                    }
                    else
                    {
                        currentDirection = Direction.right;
                        minIndexY++;
                        indexY++;
                        indexX++;
                    }
                    break;
            }
        }

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write(array[i, j].ToString().PadLeft(4));
            }
            Console.WriteLine();
        }

    }
}

