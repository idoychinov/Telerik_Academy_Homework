/* Problem 6. * Write a class Matrix, to holds a matrix of integers. Overload the operators for adding, subtracting and multiplying of matrices, indexer for accessing the matrix content and ToString().
*/

using System;
using System.Text;

class Matrix
{
    private int[,] values;
    private int row, col;

    public Matrix(int rows, int cols)
    {
        row = rows;
        col = cols;
        values = new int[rows, cols];
    }

    public int this[int rowIndex, int colIndex]
    {
        get
        {
            if (rowIndex >= row || colIndex >= col || rowIndex < 0 || colIndex < 0)
            {
                throw new System.IndexOutOfRangeException("Glitch in the Matrix detected!");
            }
            return values[rowIndex, colIndex];
        }
        set
        {
            if (rowIndex >= row || colIndex >= col || rowIndex < 0 || colIndex < 0)
            {
                throw new System.IndexOutOfRangeException("Glitch in the Matrix detected!");
            }
            values[rowIndex, colIndex] = value;
        }
    }

    static public Matrix operator +(Matrix operand1, Matrix operand2)
    {
        if ((operand1.row != operand2.row) || (operand1.col != operand2.col))
        {
            throw new System.InvalidOperationException("Addition is not posibble for matrices with diferent sizes");
        }
        Matrix result = new Matrix(operand1.row, operand2.col);
        for (int i = 0; i < result.row; i++)
        {
            for (int j = 0; j < result.col; j++)
            {
                result[i, j] = operand1[i, j] + operand2[i, j];
            }
        }
        return result;
    }

    static public Matrix operator -(Matrix operand1, Matrix operand2)
    {
        if ((operand1.row != operand2.row) || (operand1.col != operand2.col))
        {
            throw new System.InvalidOperationException("Substraction is not posibble for matrices with diferent sizes");
        }
        Matrix result = new Matrix(operand1.row, operand2.col);
        for (int i = 0; i < result.row; i++)
        {
            for (int j = 0; j < result.col; j++)
            {
                result[i, j] = operand1[i, j] - operand2[i, j];
            }
        }
        return result;
    }

    static public Matrix operator *(Matrix operand1, Matrix operand2)
    {
        if ((operand1.col != operand2.row))
        {
            throw new System.InvalidOperationException("Multiplication is only posible if one of the matrices have the same number of columns as the other has rows");
        }
        Matrix result = new Matrix(operand1.row, operand2.col);
        for (int i = 0; i < result.row; i++)
        {
            for (int j = 0; j < result.col; j++)
            {
                for (int k = 0; k < operand1.col; k++)
                {
                    result[i, j] += operand1[i, k]*operand2[k, j];
                }
            }
        }
        return result;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                result.Append(this[i, j].ToString().PadLeft(3));
            }
            result.Append("\n");
        }
        result.Remove(result.Length - 1, 1);
        return result.ToString();
    }

    static void Main()
    {
        Matrix matrix1 = new Matrix(3, 3);
        Matrix matrix2 = new Matrix(3, 3);
        Matrix matrix3 = new Matrix(2, 3);
        Matrix matrix4 = new Matrix(3, 2);

        matrix1.values = new int[,] {
        { 5, -4, 3 }, 
        { 2, 7, -1 }, 
        { 0, 1, 4 } };

        matrix2.values = new int[,] {
        { 2, 4, 1 }, 
        { 3, -7, 0 }, 
        { 5, 9, 7 } };

        matrix3.values = new int[,] {
        { 1, 2, 3 }, 
        { 4, 5, 6 }};

        matrix4.values = new int[,] {
        { 7, 8 }, 
        { 9, 10}, 
        { 11,12}};

        while (true)
        {
            Console.WriteLine("Select by pressing the apropriate key on the keyboard");
            Console.WriteLine("1- Add matrixes");
            Console.WriteLine("2- Substract matrixes");
            Console.WriteLine("3- Multiplicate matrixes");
            Console.WriteLine("e- Exit");
            Console.WriteLine("Chose operation:");
            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine();
            switch (key.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Add(matrix1, matrix2);
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Substract(matrix1, matrix2);
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    Multiplication(matrix3, matrix4);
                    break;
                case ConsoleKey.E:
                    return;
            }
            Console.WriteLine();
        }


    }

    static void Add(Matrix matrix1, Matrix matrix2)
    {
        Console.WriteLine("Addition");
        Console.WriteLine(matrix1.ToString());
        Console.WriteLine("\n     +\n");
        Console.WriteLine(matrix2.ToString());
        Console.WriteLine("\n     =\n");
        Console.WriteLine((matrix1 + matrix2).ToString());
    }

    static void Substract(Matrix matrix1, Matrix matrix2)
    {
        Console.WriteLine("Addition");
        Console.WriteLine(matrix1.ToString());
        Console.WriteLine("\n     -\n");
        Console.WriteLine(matrix2.ToString());
        Console.WriteLine("\n     =\n");
        Console.WriteLine((matrix1 - matrix2).ToString());
    }

    static void Multiplication(Matrix matrix1, Matrix matrix2)
    {
        Console.WriteLine("Multiplication");
        Console.WriteLine(matrix1.ToString());
        Console.WriteLine("\n     *\n");
        Console.WriteLine(matrix2.ToString());
        Console.WriteLine("\n     =\n");
        Console.WriteLine((matrix1 * matrix2).ToString());
    }
}

