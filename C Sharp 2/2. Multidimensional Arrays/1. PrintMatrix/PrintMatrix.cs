/* Problem 1. Write a program that fills and prints a matrix of size (n, n) as shown below: (examples for n = 4)
*/

using System;

class PrintMatrix
{
    static void FillMatrix(int[,] mat, char mode)
    {
        int n = mat.GetLength(0);
        int row, count;
        string direction;
        switch (mode)
        {
            case 'a':
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        mat[i,j]=i + 1 + (j * n);
                    }
                }
                
                break;
            case 'b':
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (j % 2 == 0)
                        {
                            mat[i, j] = i + 1+(j*n);
                        }
                        else
                        {
                            mat[i, j] = (n-i)+j*n;
                        }
                        
                    }
                }
                break;
            case 'c':
                count = 1;
                for (int i = n-1; i >= 0; i--)
                {
                    row=i;
                    for (int j = 0; j < (n-i); j++)
                    {
                        mat[row,j]=count;
                        count++;
                        row++;
                    }
                }
                for (int i = 0; i < n-1 ; i++)
                {
                    row = 0;
                    for (int j = 1+i; j < n; j++)
                    {
                        mat[row, j] = count;
                        count++;
                        row++;
                    }
                }

                break;
            case 'd':
                
                int constraint = n,rotation=0,x=0,y=0,cycle=0;

                direction = "down";
                for (int i = 1; i <= n*n; i++)
                {
                    switch (direction)
                    {
                        case "down": mat[x, y] = i; x++; break;
                        case "right": mat[x, y] = i; y++; break;
                        case "top": mat[x, y] = i; x--; break;
                        case "left": mat[x, y] = i; y--; break;
                    }
                    if (i == constraint)
                    {
                        cycle++;
                        if(cycle%2!=0)
                        {
                            rotation++;
                        }
                        constraint = constraint + n - rotation;
                        switch (direction)
                        {
                            case "down": direction = "right"; x--; y++; break;
                            case "right": direction = "top"; y--; x--; break;
                            case "top": direction = "left"; x++; y--; break;
                            case "left": direction = "down"; y++; x++;  break;
                        }
                    }

                }
                break;
        }
        PrintMatrix(mat);
    }

    static void PrintMatrix(int[,] mat)
    {
        int n = mat.GetLength(0);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0,4} ",mat[i,j]);
            }
            Console.WriteLine();
        }
	{
		 
	}
    }
    static void Main()
    {
        int N;
        Console.Write("Enter N=");
        N = int.Parse(Console.ReadLine());
        int[,] matrix = new int[N, N];
        Array.Clear(matrix,0,N);
        Console.WriteLine("a)");
        FillMatrix(matrix, 'a');
        Console.WriteLine("b)");
        FillMatrix(matrix, 'b');
        Console.WriteLine("c)");
        FillMatrix(matrix, 'c');
        Console.WriteLine("d)");
        FillMatrix(matrix, 'd');
    }
}

