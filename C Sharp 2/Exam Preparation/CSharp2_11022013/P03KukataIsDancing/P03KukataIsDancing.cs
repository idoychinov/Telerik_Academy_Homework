using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03KukataIsDancing
{
    class P03KukataIsDancing
    {
        ///
        ///unfinished;
        ///
        static char[, ,] cube = { 
                             {{'R','B','R'},{'B','G','B'},{'R','B','R'}},
                             {{'B','G','B'},{'G','G','G'},{'B','G','B'}},
                             {{'R','B','R'},{'B','G','B'},{'R','B','R'}},
                             };

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
  
        private static char Move(string moves)
        {
            int[] hook={2,1,1};
            int[] direction = { 0, 1, 0 };
            for (int i = 0; i < moves.Length; i++)
            {
                switch (moves[i])
                {
                    case'L' :
                        break;
                    case'R':
                        break;
                    case'W':
                        for (int j = 0; j < 3; j++)
                        {
                            if ((hook[j] + direction[j]) > 2 )
                            {
                                direction[j] = 0;
                                
                            }
                            else if((hook[j] + direction[j]) < 0)
                            {
                                direction[j] = 0;
                            }
                            else
                            {
                                hook[j] += direction[j];
                            }
                        }

                        break;
                }
            }
            return cube[hook[0], hook[1], hook[2]];
        }
    }
}
