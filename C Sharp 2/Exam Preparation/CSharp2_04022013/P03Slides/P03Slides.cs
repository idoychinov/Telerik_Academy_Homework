using System;
using System.Linq;
using System.Collections.Generic;

namespace P03Slides
{
    class P03Slides
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> dimensions = new Dictionary<char, int>(3);
            Dictionary<char, int> ball = new Dictionary<char, int>(3);
            dimensions = SetCoordinates(Console.ReadLine(), false);
            string[, ,] cube = GetInput(dimensions['W'], dimensions['H'],dimensions['D']);
            ball = SetCoordinates(Console.ReadLine(), true);
            int result=0;
            while (result == 0)
            {
                result = MoveBall(ball,cube);
            }
            if (result == 1)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
            Console.WriteLine(ball['W']+" "+ball['H']+" "+ball['D']);
        }
  
        private static int MoveBall(Dictionary<char, int> ball,string[,,] cube)
        {
            if (cube[ball['W'], ball['H'], ball['D']][0] == 'B')
            {
                return 2;
            }
            else if (cube[ball['W'], ball['H'], ball['D']][0] == 'E')
            {
                if (ball['H'] + 1 == cube.GetLength(1))
                {
                    return 1;
                }
                else
                {
                    ball['H'] = ball['H'] + 1;
                    return 0;
                }
            }
            else if (cube[ball['W'], ball['H'], ball['D']][0] == 'T')
            {
                string[] teleport = cube[ball['W'], ball['H'], ball['D']].Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
                ball['W'] = int.Parse(teleport[1]);
                ball['D'] = int.Parse(teleport[2]);
                return 0;
            }
            else 
            {
                return Slide(ball, cube);
            }
        }

        static int Slide(Dictionary<char, int> ball, string[, ,] cube)
        {
            if (ball['H'] + 1 >= cube.GetLength(1))
            {
                return 1;
            }
            else
            {
                string[] slide = cube[ball['W'], ball['H'], ball['D']].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                switch (slide[1])
                {
                    case "L":
                        if (ball['W'] - 1 < 0)
                        {
                            return 2;
                        }
                        else
                        {
                            ball['W'] = ball['W'] - 1;
                            ball['H'] = ball['H'] + 1;
                        }
                        break;
                    case "R":
                        if (ball['W'] + 1 >= cube.GetLength(0))
                        {
                            return 2;
                        }
                        else
                        {
                            ball['W'] = ball['W'] + 1;
                            ball['H'] = ball['H'] + 1;
                        }
                        break;
                    case "F":
                        if (ball['D'] - 1 < 0)
                        {
                            return 2;
                        }
                        else
                        {
                            ball['D'] = ball['D'] - 1;
                            ball['H'] = ball['H'] + 1;
                        }
                        break;
                    case "B":
                        if (ball['D'] + 1 >= cube.GetLength(2))
                        {
                            return 2;
                        }
                        else
                        {
                            ball['D'] = ball['D'] + 1;
                            ball['H'] = ball['H'] + 1;
                        }
                        break;
                    case "FL":
                        if (ball['W'] - 1 < 0 || ball['D'] - 1 < 0)
                        {
                            return 2;
                        }
                        else
                        {
                            ball['W'] = ball['W'] - 1;
                            ball['D'] = ball['D'] - 1;
                            ball['H'] = ball['H'] + 1;
                        }
                        break;
                    case "FR":
                        if (ball['W'] + 1 >= cube.GetLength(0) || ball['D'] - 1 < 0)
                        {
                            return 2;
                        }
                        else
                        {
                            ball['W'] = ball['W'] + 1;
                            ball['D'] = ball['D'] - 1;
                            ball['H'] = ball['H'] + 1;
                        }
                        break;
                    case "BL":
                        if (ball['W'] - 1 < 0 || ball['D'] + 1 >= cube.GetLength(2))
                        {
                            return 2;
                        }
                        else
                        {
                            ball['D'] = ball['D'] + 1;
                            ball['W'] = ball['W'] - 1;
                            ball['H'] = ball['H'] + 1;
                        }
                        break;
                    case "BR":
                        if (ball['W'] + 1 >= cube.GetLength(0) || ball['D'] + 1 >= cube.GetLength(2))
                        {
                            return 2;
                        }
                        else
                        {
                            ball['D'] = ball['D'] + 1;
                            ball['W'] = ball['W'] + 1;
                            ball['H'] = ball['H'] + 1;
                        }
                        break;
                }
            }
            return 0;
        }
        static Dictionary<char, int> SetCoordinates(string input, bool ball)
        {
            int coordinates = 3;
            if (ball)
            {
                coordinates = 2;
            }
            string[] arr = new string[coordinates];
            arr = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<char, int> output = new Dictionary<char, int>(coordinates);
            output.Add('W', int.Parse(arr[0]));
            output.Add('D', int.Parse(arr[coordinates - 1]));
            if (ball)
            {
                output.Add('H', 0);
            }
            else
            {
                output.Add('H', int.Parse(arr[1]));
            }
            return output;
        }

        static string[, ,] GetInput(int W, int H,int D )
        {
            string[, ,] cube = new string[W, H, D];
            for (int i = 0; i < H; i++)
            {
                string line = Console.ReadLine();
                string[] sequences = GetSequences(line);
                for (int j = 0; j < D; j++)
                {
                    string[] cells = GetCells(sequences[j]);
                    for (int k = 0; k < W; k++)
                    {
                        cube[k, i, j] = cells[k];
                    }
                }

            }

            return cube;
        }

        private static string[] GetSequences(string line)
        {
            return line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private static string[] GetCells(string sequences)
        {
            return sequences.Trim().Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
