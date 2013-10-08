using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    // Problem 8. Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals). 

    class Matrix<T>
        where T : struct, IComparable
    {
        private T[,] matrixValues;
        private int rows;
        private int columns;

        public int Rows
        {
            get
            {
                return this.rows;
            }
        }

        public int Columns
        {
            get
            {
                return this.columns;
            }
        }

        public Matrix(int rows, int columns)
        {
            this.matrixValues = new T[rows, columns];
            this.rows = Rows;
            this.columns = Columns;
        }

        // Problem 9. Implement an indexer this[row, col] to access the inner matrix cells.
        public T this[int rowIndex, int colIndex]
        {
            get
            {
                if (rowIndex >= rows || colIndex >= columns || rowIndex < 0 || colIndex < 0)
                {
                    throw new System.IndexOutOfRangeException("Glitch in the Matrix detected!");
                }
                return matrixValues[rowIndex, colIndex];
            }
            set
            {
                if (rowIndex >= rows || colIndex >= columns || rowIndex < 0 || colIndex < 0)
                {
                    throw new System.IndexOutOfRangeException("Glitch in the Matrix detected!");
                }
                matrixValues[rowIndex, colIndex] = value;
            }
        }

        // Problem 10. Implement the operators + and - (addition and subtraction of matrices of the same size) and * for matrix multiplication. 
        // Throw an exception when the operation cannot be performed. Implement the true operator (check for non-zero elements).

        static public Matrix<T> operator +(Matrix<T> operand1, Matrix<T> operand2)
        {
            if ((operand1.rows != operand2.rows) || (operand1.columns != operand2.columns))
            {
                throw new System.InvalidOperationException("Addition is not posibble for matrices with diferent sizes");
            }
            Matrix<T> result = new Matrix<T>(operand1.rows, operand2.columns);
            for (int i = 0; i < result.rows; i++)
            {
                for (int j = 0; j < result.columns; j++)
                {
                    dynamic value1 = operand1[i, j];
                    dynamic value2 = operand2[i, j];
                    dynamic currentValue = value1 + value2;
                    result[i, j] = currentValue;
                }
            }
            return result;
        }

        static public Matrix<T> operator -(Matrix<T> operand1, Matrix<T> operand2)
        {
            if ((operand1.rows != operand2.rows) || (operand1.columns != operand2.columns))
            {
                throw new System.InvalidOperationException("Substraction is not posibble for matrices with diferent sizes");
            }
            Matrix<T> result = new Matrix<T>(operand1.rows, operand2.columns);
            for (int i = 0; i < result.rows; i++)
            {
                for (int j = 0; j < result.columns; j++)
                {
                    dynamic value1 = operand1[i, j];
                    dynamic value2 = operand2[i, j];
                    dynamic currentValue = value1 - value2;
                    result[i, j] = currentValue;
                }
            }
            return result;
        }

        static public Matrix<T> operator *(Matrix<T> operand1, Matrix<T> operand2)
        {
            if ((operand1.columns != operand2.rows))
            {
                throw new System.InvalidOperationException("Multiplication is only posible if one of the matrices have the same number of columns as the other has rows");
            }
            Matrix<T> result = new Matrix<T>(operand1.rows, operand2.columns);
            for (int i = 0; i < result.rows; i++)
            {
                for (int j = 0; j < result.columns; j++)
                {
                    for (int k = 0; k < operand1.columns; k++)
                    {
                        dynamic value1 = operand1[i, k];
                        dynamic value2 = operand2[k, j];
                        dynamic currentValue = value1 * value2;
                        result[i, j] += currentValue;
                    }
                }
            }
            return result;
        }

        public static bool operator true(Matrix<T> matrix)
        {
            if (matrix == null || matrix.rows == 0 || matrix.columns == 0)
            {
                return false;
            }

            for (int row = 0; row < matrix.rows; row++)
            {
                for (int col = 0; col < matrix.columns; col++)
                {
                    if (!matrix[row, col].Equals(default(T)))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            if (matrix == null || matrix.rows == 0 || matrix.columns == 0)
            {
                return true;
            }

            for (int row = 0; row < matrix.rows; row++)
            {
                for (int col = 0; col < matrix.columns; col++)
                {
                    if (!matrix[row, col].Equals(default(T)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }

}
