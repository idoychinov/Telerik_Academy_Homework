namespace Task01NestedLoops
{
    using System;

    class Task01NestedLoops
    {
        static void Main()
        {
            var n = 4;
            Loop(0,n,new int[n]);
        }

        static void Loop(int current,int n, int[] output)
        {
            if(current>=n)
            {
                Console.WriteLine(string.Join(", ",output));
                return;
            }


            for (int i = 1; i <= n; i++)
            {
                output[current] = i;
                Loop(current+1, n,output);
            }
        }
    }
}
