/* Problem 11. * Implement the "Falling Rocks" game in the text console. A small dwarf stays at the bottom of the screen and can move left and right (by the arrows keys). A number of rocks of different   * sizes and forms constantly fall down and you need to avoid a crash.
 * Rocks are the symbols ^, @, *, &, +, %, $, #, !, ., ;, - distributed with appropriate density. The dwarf is (O). Ensure a constant game speed by Thread.Sleep(150).
 * Implement collision detection and scoring system.
 */

using System;
using System.Collections.Generic;
using System.Threading;


class FallingRocks
{
    const int MaxHeight = 40;
    const int MaxWidth = 60;
    const int Speed = 20;
    const int Spawn = 8;
    const int MaxLives = 5;
    const int MenuHeight = 6;
    const int RockFallScore = 20;
    const int MoveStep = 1;
    static readonly char[] enemySymbols = { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';', '-' };
    private static int score;
    private static int lives=MaxLives;
    private static int position;
    private static int cycle;
    private static List<Rock> rocks = new List<Rock>();
    private static Random rand = new Random();

    class Rock
    {
        private int x;
        private int y;
        private int size;
        private string symbol;
        private ConsoleColor color;

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public int Size
        {
            get { return size; }
        }

        public string Symbol
        {
            get { return symbol; }
        }

        public ConsoleColor Color
        {
            get { return color; }
        }
        public Rock(int xCoordinate, char sym)
        {
            x = xCoordinate;
            y = MenuHeight + 1;
            
            int s = rand.Next(1, 1000);

            if (x == (MaxWidth - 2))
            {
                size = 1;
            }
            else if (x == (MaxWidth - 3))
            {
                if (s > 700)
                {
                    size = 2;
                }
                else
                {
                    size = 1;
                }
            }
            else
            {
                if (s < 600)
                {
                    size = 1;
                }
                else if (s < 900)
                {
                    size = 2;
                }
                else
                {
                    size = 3;
                }
            }

            symbol = new string (sym,size);

            int col = rand.Next(1, 14);
            if (col == 14)
            {
                col = 15;
            }
            color = (ConsoleColor)col;
        }

        public bool Fall()
        {
            this.y = this.y + 1;
            if (this.y >= MaxHeight-1)
            {
                return true;
            }
            return false;
        }
        
    }

    static void Main()
    {
        Initialize();
        StartScreen();
        GameEndgine();
    }

    private static void GameEndgine()
    {
        ConsoleKeyInfo key;
        while (true)
        {
            if (Console.KeyAvailable)
            {
                key = Console.ReadKey(true);
                //while (Console.KeyAvailable) { Console.ReadKey(true); }

                if (key.Key == ConsoleKey.LeftArrow)
                {
                    ClearAtPositon(position+1, MaxHeight - 2, 1);
                    position -= MoveStep;
                    if (position < 2)
                    {
                        position = 2;
                    }
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    ClearAtPositon(position - 1, MaxHeight - 2, 1);
                    position += MoveStep;
                    if (position > MaxWidth - 3)
                    {
                        position = MaxWidth - 3;
                    }
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    
                    Console.SetCursorPosition((MaxWidth / 2) - 13, MaxHeight / 2);
                    Console.Write("           PAUSE           ");
                    Console.SetCursorPosition((MaxWidth / 2) - 13, (MaxHeight / 2) +1);
                    Console.Write("                           ");
                    Console.SetCursorPosition((MaxWidth / 2) - 13, (MaxHeight / 2) + 2);
                    Console.WriteLine(" Press any key to continue ");
                    Console.ReadKey(true);
                    ClearAtPositon((MaxWidth / 2) - 13, MaxHeight / 2, 27);
                    ClearAtPositon((MaxWidth / 2) - 13, (MaxHeight / 2) + 1, 27);
                    ClearAtPositon((MaxWidth / 2) - 13, (MaxHeight / 2) + 2, 27);
                }
            }
            UpdateObjects();
            if (CheckColision())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition((MaxWidth / 2) - 3, MaxHeight / 2);
                Console.Write("GAME OVER!");
                Console.SetCursorPosition((MaxWidth / 2) - 8, (MaxHeight / 2) + 2);
                Console.WriteLine("Press any key to exit");
                Console.ReadKey(true);
                return;
            }
            DrawScreen();
            Thread.Sleep(Speed);
            score++;
        }

    }

    private static bool CheckColision() //reutrn true when zero lives are left
    {
        foreach (Rock item in rocks)
        {
            if (item.Y == (MaxHeight - 2))
            {
                bool colision=false;
                if ((item.Size == 1) && ((item.X == position) || (item.X == position - 1) || (item.X == position + 1)))
                {
                    colision = true;
                }
                else if ((item.Size == 2) && ((item.X == position) || (item.X == position - 1) || (item.X == position + 1) || (item.X == position -2)))
                {
                    colision = true;
                }
                else if ((item.Size == 3) && ((item.X == position) || (item.X == position - 1) || (item.X == position + 1) || (item.X == position -2) || (item.X == position - 3)))
                {
                    colision = true;
                }
                
                if (colision)
                {
                    lives--;
                    DrawScreen();
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(200);
                    Console.SetCursorPosition(position - 1, MaxHeight - 2);
                    Console.Write(@"|O|");
                    Thread.Sleep(200);
                    Console.SetCursorPosition(position - 1, MaxHeight - 2);
                    Console.Write(@"\O/");
                    Thread.Sleep(200);
                    Console.SetCursorPosition(position - 1, MaxHeight - 2);
                    Console.Write(@"_~_");
                    Thread.Sleep(200);
                    Console.SetCursorPosition(position - 1, MaxHeight - 2);
                    Console.Write(@"X_X");
                    Thread.Sleep(1400);
                    
                    foreach (Rock rock in rocks)
                    {
                        ClearAtPositon(rock.X, rock.Y, rock.Size);
                    }

                    rocks.Clear();
                    if (lives == 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }
        return false;
    }

    private static void UpdateObjects()
    {
        cycle++;
        if (cycle == Spawn)
        {
            cycle = 0;
            int i = 0;
            while (true)
            {
                if (i >= rocks.Count)
                {
                    break;
                }
                ClearAtPositon(rocks[i].X, rocks[i].Y, rocks[i].Size);
                if (rocks[i].Fall())
                {
                    rocks.RemoveAt(i);
                    score += RockFallScore;
                }
                else
                {
                    i++;
                }
            }
            char sym = enemySymbols[rand.Next(0, enemySymbols.Length-1)];
            int pos = rand.Next(1,MaxWidth-2);
            rocks.Add(new Rock(pos,sym));

            // implement several rocks on same row?
        }
    }

    // Clears old elements in order to prevent screen flickering and use it instead of Console.Clear in the DrawScreen method. Used when updating element in code.
    private static void ClearAtPositon(int positionX,int positionY,int lenght)  
    {
        string clear= new string(' ',lenght);
        Console.ForegroundColor = ConsoleColor.Black;
        Console.SetCursorPosition(positionX, positionY);
        Console.Write(clear);
    }

    private static void DrawScreen()
    {
        
        
        foreach (Rock item in rocks)
        {
            Console.SetCursorPosition(item.X, item.Y);
            Console.ForegroundColor = item.Color;
            Console.Write(item.Symbol);
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.SetCursorPosition((MaxWidth / 2) +2, 2);
        Console.Write(score);
        Console.SetCursorPosition((MaxWidth / 2) +2, 4);
        Console.Write(lives);

        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(position - 1, MaxHeight - 2);
        Console.Write("(O)");
    }

    private static void StartScreen()
    {
        Console.SetCursorPosition((MaxWidth / 2) - 3, MaxHeight / 2);
        Console.Write("WELCOME");
        Console.SetCursorPosition((MaxWidth / 2) - 10, (MaxHeight / 2) + 2);
        Console.WriteLine("Press any key to start");
        Console.ReadKey(true);
        ClearAtPositon((MaxWidth / 2) - 3, MaxHeight / 2, 7);
        ClearAtPositon((MaxWidth / 2) - 10, (MaxHeight / 2) + 2 , 22);
    }

    private static void Initialize()
    {
        Console.Clear();
        Console.WindowHeight = MaxHeight;
        Console.BufferHeight = MaxHeight;
        Console.WindowWidth = MaxWidth;
        Console.BufferWidth = MaxWidth;
        Console.CursorVisible = false;
        score = 0;
        cycle = 0;
        position = MaxWidth / 2;

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.SetCursorPosition((MaxWidth / 2) - 5, 2);
        Console.Write("SCORE: {0}", score);
        Console.SetCursorPosition((MaxWidth / 2) - 5, 4);
        Console.Write("LIVES: {0}", lives);
        Console.SetCursorPosition(1, 0);
        Console.Write(new string('-', MaxWidth - 2));
        Console.SetCursorPosition(1, 6);
        Console.Write(new string('-', MaxWidth-2));
        Console.SetCursorPosition(1, MaxHeight - 1);
        Console.Write(new string('-', MaxWidth-2));
        for (int i = 1; i < MaxHeight-1; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.Write("|");
            Console.SetCursorPosition(MaxWidth-1, i);
            Console.Write("|");
        }
        
    }
}
