using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05ThreeInOne
{
    class P05ThreeInOne
    {

        /// <summary>
        /// UNFINISHED 60/100
        /// </summary>
        /// 
        static void Main(string[] args)
        {
            int[] firstTask = GetInput();
            Console.WriteLine(BlackJack(firstTask));
            int[] secondTask = GetInput();
            int secondTaskFriends = int.Parse(Console.ReadLine());
            Console.WriteLine(Cakes(secondTask, secondTaskFriends));
            int[] thirdTask = GetInput();
            Console.WriteLine(Gold(thirdTask));
        }

        private static int Gold(int[] coins)
        {
            int steps=0;
            int myCoinsTotal = (coins[0] * 9 * 11) + (coins[1] * 11) + (coins[2]);
            int bearCoinsTotal = (coins[3] * 9 * 11) + (coins[4] * 11) + (coins[5]);
            if (myCoinsTotal < bearCoinsTotal)
            {
                return -1;
            }

            while (coins[0] < coins[3] || coins[1] < coins[4] || coins[2] < coins[5])
            {
                steps++;
                int silverInGold = (coins[1]/9);
                int bronzeInSilver = (coins[2]/9);
                if (coins[0] < coins[3])
                {
                    if ((coins[0] + silverInGold) < coins[3])
                    {
                        coins[2] -= 11;
                        coins[1]++;
                    }
                    else
                    {
                        coins[1] -= 11;  // check for bronze to silver?
                        coins[0]++;
                    }
                }
                else if (coins[1] < coins[4])
                {
                    if (coins[2] < coins[4])
                    {
                        coins[0] -= 1;
                        coins[1]+=9;
                    }
                    else
                    {
                        coins[2] -= 11;
                        coins[1]++;
                    }
                }
                else
                {
                    if (coins[1] == 0)
                    {
                        coins[0]--;
                        coins[1] += 9;
                    }
                    else
                    {
                        coins[1]--;
                        coins[2] += 9;
                    }
                }

            }
            return steps;
        }

        private static int Cakes(int[] cakes, int friends)
        {
            int bites = 0;
            cakes = cakes.OrderByDescending(x => x).ToArray();
            int myturn = 0;
            for (int i = 0; i < cakes.Length; i++)
            {
                if (myturn == 0)
                {
                    bites += cakes[i];

                }
                myturn = (myturn + 1) % (friends + 1);
            }
            return bites;
        }

        private static int BlackJack(int[] input)
        {
            int maxPoints = 0;
            int winnerIndex = -1;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] <= 21)
                {
                    if (input[i] > maxPoints)
                    {
                        maxPoints = input[i];
                        winnerIndex = i;
                    }
                    else if (input[i] == maxPoints)
                    {
                        return -1;
                    }

                }
            }
            return winnerIndex;
        }

        private static int[] GetInput()
        {
            char[] splitSeparators = { ',', ' ' };
            string[] input = Console.ReadLine().Split(splitSeparators, StringSplitOptions.RemoveEmptyEntries);
            return input.Select(x => int.Parse(x)).ToArray();
        }


    }
}
