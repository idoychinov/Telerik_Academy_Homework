/* Problem 4. Write a program that calculates N!/K! for given N and K (1<K<N).
 */
using System;
using MyIO; //using methods defined in another project within the solution.
using System.Numerics;

class FactorielDivisionNK
{
    static void Main()
    {
        ulong N,K;
        BigInteger factoriel=1;

        while (true)
        {
            MyIOClass.Input(out N, "Enter the number N: ");
            MyIOClass.Input(out K, "Enter the number K: ");
            if((K>1)&&(N>K))
            {
                break;
            }
            Console.WriteLine("\nThe numbers must be as follows (1<K<N)!\n");
        }

        for (ulong i = K+1; i <= N; i++)
		{

            factoriel *= (BigInteger)i;
            
		}
        Console.WriteLine("N!/K! is: {0:e} \nor : {0}", factoriel);
        
    }
}

