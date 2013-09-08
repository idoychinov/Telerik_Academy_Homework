using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03KukataIsDancing2DSolution
{
    class P03KukataIsDancing2DSolution
    {
        static string[,] field = { { "RED", "BLUE", "RED" }, { "BLUE", "GREEN", "BLUE", }, { "RED", "BLUE", "RED" } };

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string[] moves = new string[count];
            for (int i = 0; i < count; i++)
            {
                moves[i] = Console.ReadLine();
            }

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(Move(moves[i]));
            }
        }

        private static string Move(string moves)
        {
            int[] hook = { 1, 1 };
            int direction = 0;

            for (int i = 0; i < moves.Length; i++)
            {
                switch (moves[i])
                {
                    case 'L':
                        direction = (direction + 3) % 4;
                        break;
                    case 'R':
                        direction = (direction + 1) % 4;
                        break;
                    case 'W':
                        switch (direction)
                        {
                            case 0:
                                hook[0] = (hook[0] + 1)%3;
                                hook[1] = hook[1];
                                break;
                            case 1:
                                hook[0] = hook[0];
                                hook[1] = (hook[1] +2)%3 ;
                                break;
                            case 2:
                                hook[0] = (hook[0] + 2) %3;
                                hook[1] = hook[1];
                                break;
                            case 3:
                                hook[0] = hook[0];
                                hook[1] = (hook[1] + 1)%3;
                                break;
                        }                       
                        break;
                }
            }
            return field[hook[0], hook[1]];
        }
    }
}
