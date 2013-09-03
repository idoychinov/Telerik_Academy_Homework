/* Problem 5. Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).
 */
using System;
using MyIO; //using methods defined in another project within the solution.
using System.Numerics; 

class FactorieleNKDivKminusN
{
    static void Main()
    {
        ulong N, K,devider;
        BigInteger factoriel=1;

        while (true)
        {
            MyIOClass.Input(out N, "Enter the number N: ");
            MyIOClass.Input(out K, "Enter the number K: ");
            if ((N > 1) && (K > N))
            {
                break;
            }
            Console.WriteLine("\nThe numbers must be as follows (1<N<K)!\n");
        }
        devider = K - N;
        for (ulong i = 2; i <= K; i++)
        {
            if (i <= N)
            {
                factoriel *= i;
            }
            if (i > devider)
            {
                factoriel *= i;
            }
        }


        Console.WriteLine("(N!*K!)/(K-N)! is: {0:e} \nor {0}", factoriel);

    }
}

