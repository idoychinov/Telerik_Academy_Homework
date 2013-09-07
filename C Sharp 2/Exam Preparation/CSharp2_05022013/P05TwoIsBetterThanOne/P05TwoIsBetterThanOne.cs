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
            Console.WriteLine(FindE(list,percentile));
        }

        private static int FindE(int[] list, int percentile)
        {
            
            Array.Sort(list);
            for (int i = 0; i < list.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < list.Length; j++)
                {
                    if (list[i] >= list[j])
                    {
                        count++;
                    }
                }
                if(count>=list.Length*(percentile/100.0))
                {
                    return list[i];
                }
            }
            return list[list.Length-1];
        }

        private static int PalindromeCount(long A, long B)
        {
            int count = 0;
            int left = 0;

            var numbers = new List<long> { 3, 5 };
            while (left < numbers.Count)
            {
                int right = numbers.Count;
                for (int i = left; i < right; i++)
                {
                    if (numbers[i] < B)
                    {
                        long temp;
                        temp = (numbers[i] * 10) + 3;
                        numbers.Add(temp);
                        temp = (numbers[i] * 10) + 5;
                        numbers.Add(temp);
                        
                    }
                }
                left = right;
            }
            foreach (var item in numbers)
            {
                if (item >= A && item<=B && IsPalindrome(item))
                        {
                            count++;
                        }
            }
            return count;
        }

        static bool IsPalindrome(long input)
        {
            string number = input.ToString();
            for (int i = 0; i < number.Length/2; i++)
            {
                if (number[i] != number[number.Length - 1 - i])
                        {
                            return false;
                        }
                        
            }
            return true;
        }
    }
}
