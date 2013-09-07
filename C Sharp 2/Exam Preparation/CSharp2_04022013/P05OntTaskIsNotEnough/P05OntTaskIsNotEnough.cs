using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05OntTaskIsNotEnough
{
    class P05OntTaskIsNotEnough
    {
        static void Main()
        {
            Console.WriteLine(Lamps());
            Console.WriteLine(Robot());
            Console.WriteLine(Robot());
        }

        private static int Lamps()
        {

            int N = int.Parse(Console.ReadLine());
            int lampsLeft = N;
            int[] lampsToTurn = new int[N + 1];
            int[] lampsOff = new int[N + 1];

            for (int i = 1; i <= lampsLeft; i ++)
            {
                lampsOff [i]= i;
                
            }
            
            int step = 0;
            while (lampsLeft > 1)
            {
                step++;
                int index = 1;
                while (index <= lampsLeft)
                {
                    lampsToTurn[index] = step;
                    index += step + 1;
                }

                int newLampsLeft = 0;
                for (int i = 1; i <= lampsLeft; i++)
                {
                    if (lampsToTurn[i] != step)
                    {
                        newLampsLeft++;
                        lampsOff[newLampsLeft] = lampsOff[i];
                    }
                }
                lampsLeft = newLampsLeft;
            }

            return lampsOff[1];
        }

        // another solution that is slower.


        //private static int Lamps()
        //{

        //    int N = int.Parse(Console.ReadLine());
        //    Console.WriteLine("{0:O}", DateTime.Now);
        //    if (N == 1)
        //    {
        //        return 1;
        //    }
        //    List<int> lamps = new List<int>((N / 2) + 1);
        //    for (int i = 2; i <= N; i += 2)
        //    {
        //        lamps.Add(i);
        //    }
        //    int last = 1;
        //    int step = 3;
        //    while (lamps.Count != 0)
        //    {
        //        last = SwithOn(ref lamps, step);
        //        step++;
        //    }
        //    Console.WriteLine("{0:O}", DateTime.Now);
        //    return last;
        //}



        //private static int SwithOn( ref List<int>  lamps, int step)
        //{
        //    int last=lamps[0];
        //    List<int> temp = new List<int>(lamps.Count);
        //    for (int i = 1; i < lamps.Count; i++)
        //    {
        //        if (i % step != 0)
        //        {
        //            temp.Add(lamps[i]);
        //        }
        //        else
        //        {
        //            last = lamps[i];
        //        }
        //    }
        //    lamps = temp;
        //    return last;
        //}

        private static string Robot()
        {
            string commands = Console.ReadLine();
            int x = 0, y = 0;
            int direction = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < commands.Length; j++)
                {

                    switch (commands[j])
                    {
                        case 'L':
                            direction = (direction + 3) % 4;
                            break;
                        case 'R':
                            direction = (direction + 1) % 4;
                            break;
                        case 'S':
                            if (direction == 0)
                            {
                                x++;
                            }
                            else if (direction == 1)
                            {
                                y++;
                            }
                            else if (direction == 2)
                            {
                                x--;
                            }
                            else if (direction == 3)
                            {
                                y--;
                            }
                            break;
                    }
                }
            }

            if (x == 0 && y == 0)
            {
                return "bounded";
            }
            else
            {
                return "unbounded";

            }
        }
    }
}
