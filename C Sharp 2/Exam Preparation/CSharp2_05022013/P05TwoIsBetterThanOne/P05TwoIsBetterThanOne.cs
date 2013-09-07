using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05TwoIsBetterThanOne
{
    class P05TwoIsBetterThanOne
    {
        static void Main()
        {
            string[] input1 = Console.ReadLine().Split();
            long A = long.Parse(input1[0]);
            long B = long.Parse(input1[1]);
            string[] input2 = Console.ReadLine().Split(new char[] {' ',','},StringSplitOptions.RemoveEmptyEntries);
            int percentile = int.Parse(Console.ReadLine());
            int[] list = new int[input2.Length];
            for (int i = 0; i < input2.Length; i++)
            {
                list[i] = int.Parse(input2[i]);
            }
            Console.WriteLine(PalindromeCount(A, B));
            //Console.WriteLine(FindE(list,percentile));
        }

        private static int FindE(int[] list, int percentile)
        {
            
            Array.Sort(list);
            if (percentile == 0)
            {
                return list[0];
            }
            int element = (int)((list.Length / 100d )*percentile);
            if (element >= list.Length)
            {
                element = list.Length - 1;
            }
            return list[element];
        }

        private static int PalindromeCount(long A, long B)
        {
            int count = 0;
            for (long i = A; i <= B; i++)
            {
                string  number = i.ToString();
                for (int j = 0; j <= number.Length/ 2; j++)
                {
                    if (number[j] != '5' && number[j] != '3')
                    {
                        break;
                    }
                    else
                    {
                        if (number[j] != number[number.Length - 1 - j])
                        {
                            break;
                        }
                        else
                        {
                            count++;
                        }
                    }
                }
                //char[] array = i.ToString().ToCharArray();
                //Array.Reverse(array);
                //string normal = i.ToString();
                //string reverce = new string(array);
                //if (String.Compare(normal, reverce) == 0)
                //{
                //    count++;
                //}
            }
            return count;
        }
    }
}
