using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;//only for testing
using System.Text;
using System.Threading.Tasks;


///
/// 3. Tron 3D
///

namespace Problem03
{
    class Problem03
    {
        static int[,] field;
        static int[] aPos;
        static int[] bPos;
        static int aDir;
        static int bDir;
        static string PlayerA;
        static string PlayerB;
        static int turnA, turnB;
        static int X, Y, Z;
        static int fieldLenght;

        static void Main()
        {
            //only for testing
            string file = @"..\..\..\t1.txt";
            if (File.Exists(file))
            {
                Console.SetIn(new StreamReader(file));
            }
            //only for testing


            string[] dimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            X = int.Parse(dimensions[0]);
            Y = int.Parse(dimensions[1]);
            Z = int.Parse(dimensions[2]);
            PlayerA = Console.ReadLine();
            PlayerB = Console.ReadLine();
            fieldLenght = 2 * Y + 2 * Z;
            field = new int[X + 1, fieldLenght];
            aPos = new int[] { (X + 1) / 2, Y / 2 };
            bPos = new int[] { (X + 1) / 2, Y + Z + (Y / 2) };
            aDir = 0;
            bDir = 2;
            field[(X + 1) / 2, Y / 2] = 1;
            field[(X + 1) / 2, Y + Z + (Y / 2)] = 2;

            Game();
        }

        private static void Game()
        {
            turnA = 0;
            turnB = 0;
            while (true)
            {
                Directions();
                Move(aPos, aDir, 1);
                Move(bPos, bDir, 2);
                if (CheckColision())
                {
                    break;
                }
                turnA++;
                turnB++;
            }
        }

        private static bool CheckColision()
        {
            bool pACrash = false, pBCrash = false;
            if (aPos[0] < 0 || aPos[0] > X)
            {
                pACrash = true;
            }
            if (bPos[0] < 0 || bPos[0] > X)
            {
                pBCrash = true;
            }
            if (aPos[0] == bPos[0] && aPos[1] == bPos[1])
            {
                pACrash = true;
                pBCrash = true;
            }
            if (!(pACrash || pBCrash))
            {
                if (field[aPos[0], aPos[1]] == 0)
                {
                    field[aPos[0], aPos[1]] = 1;
                }
                else
                {
                    pACrash = true;
                }

                if (field[bPos[0], bPos[1]] == 0)
                {
                    field[bPos[0], bPos[1]] = 2;
                }
                else
                {
                    pBCrash = true;
                }
            }
            try
            {
                if (pACrash && pBCrash)
                {
                    Console.WriteLine("DRAW");
                    Console.WriteLine(Math.Abs(aPos[0] - ((X + 1) / 2)) + Math.Abs(aPos[1] - (Y / 2)));
                    return true;
                }
                else if (pACrash)
                {
                    Console.WriteLine("BLUE");
                    Console.WriteLine(Math.Abs(aPos[0] - ((X + 1) / 2)) + Math.Abs(aPos[1] - (Y / 2)));
                    return true;
                }
                else if (pBCrash)
                {
                    Console.WriteLine("RED");
                    Console.WriteLine(Math.Abs(aPos[0] - ((X + 1) / 2)) + Math.Abs(aPos[1] - (Y / 2)));
                    return true;
                }
            }
            catch
            {
                throw new System.ArgumentException();
            }
            return false;
        }

        private static void Move(int[] player, int direction, int playerNumber)
        {

            switch (direction)
            {
                case 0:
                    player[1] = (player[1] + 1) % fieldLenght;
                    break;
                case 1:
                    player[0]++;
                    break;
                case 2:
                    player[1] = (player[1] - 1) % fieldLenght;
                    break;
                case 3:
                    player[0]--;
                    break;
            }


        }

        private static void Directions()
        {
            char currentTurnA;
            char currentTurnB;

            currentTurnA = PlayerA[turnA];
            currentTurnB = PlayerB[turnB];



            if (currentTurnA == 'L')
            {
                aDir = (aDir + 3) % 4;
                turnA++;

            }
            else if (currentTurnA == 'R')
            {
                aDir = (aDir + 1) % 4;
                turnA++;
            }

            if (currentTurnB == 'L')
            {
                bDir = (bDir + 3) % 4;
                turnB++;

            }
            else if (currentTurnB == 'R')
            {
                bDir = (bDir + 1) % 4;
                turnB++;

            }

        }


    }
}
