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
            int N = int.Parse(Console.ReadLine());
            bool[] lamps = new bool[N];
            int action = 1;
            int LastOffLamp=0;
            while (true)
            {
                int FirstOffLamp = Array.IndexOf(lamps, false);
                if (FirstOffLamp < 0)
                {
                    Console.WriteLine(LastOffLamp+1);
                    break;
                }

                for (int i = FirstOffLamp; i < N; i = i + (action + 1))
                {
                    if (!lamps[i])
                    {
                        lamps[i] = true;
                        LastOffLamp = i;
                    }
                }
                action++;
            }

            //    List <int> lamps= new List<int>(N);
            //    for (int i = 0; i < N; i++)
            //    {
            //        lamps.Add(i + 1);
            //    }

            //    int action = 1;
            //    int firstOffLamp = 1;
            //    Array.
            //    while (true)
            //    {
            //        int i;
            //        for (i = firstOffLamp; i < N + 1; i++)
            //        {
            //            lamps.Remove(i);
            //        }
            //        if (lamps.Count == 0)
            //        {
            //            Console.WriteLine(i);
            //            break;
            //        }
            //        action++;
            //    }
        }
    }
}
