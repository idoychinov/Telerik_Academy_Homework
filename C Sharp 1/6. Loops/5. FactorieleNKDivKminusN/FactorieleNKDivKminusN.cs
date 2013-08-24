/* Problem 5. Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).
 */
using System;
using MyIO; //using methods defined in another project within the solution.
using System.Numerics; 

class FactorieleNKDivKminusN
{
    static void Main()
    {
        uint N, K,devider;
        BigInteger factorielK = 1, factorielN = 1, factorielDevider=1;

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
        for (int i = 2; i <= K; i++)
        {
            factorielK *= i;
            if (i <= N)
            {
                factorielN *= i;
            }
            if (i <= devider)
            {
                factorielDevider *= i;
            }
        }


        Console.WriteLine("(N!*K!)/(K-N)! is: {0}", ((factorielK * factorielN) / factorielDevider));

    }
}

