/* Problem 3. We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets of several neighbor elements 
 * located on the same line, column or diagonal. Write a program that finds the longest sequence of equal strings in the matrix. 
 */
using System;

class Sequencess
{
    static void Main()
    {
        string[,] mat = 
        {
            {"ha","fifi","ho","hi"},
            {"fo","ha","hi","xx"},
            {"xxx","ho","ha","xx"},
        };

        /*
        string[,] mat = 
        {
            {"s","qq","s"},
            {"pp","pp","s"},
            {"pp","qq","s"},
        };
         */
        string sequence, maxSequence = "", display = "";
        int sequenceLenght = 1, maxSequenceLenght = 0;
        bool check = false;
        for (int i = 0; i < mat.GetLength(0); i++)
        {
            for (int j = 0; j < mat.GetLength(1); j++)
            {
                //checking right
                sequenceLenght = 1;
                sequence = mat[i, j];
                do
                {
                    check = false;
                    if (j + sequenceLenght < mat.GetLength(1))
                    {
                        if (mat[i, j + sequenceLenght] == sequence)
                        {
                            sequenceLenght++;
                            if (sequenceLenght > maxSequenceLenght)
                            {
                                maxSequenceLenght = sequenceLenght;
                                maxSequence = sequence;
                            }
                            check = true;
                        }
                    }
                } while (check);

                //checking right down diagonal
                sequenceLenght = 1;
                do
                {
                    check = false;
                    if ((i + sequenceLenght < mat.GetLength(0)) && (j + sequenceLenght < mat.GetLength(1)))
                    {
                        if (mat[i + sequenceLenght, j + sequenceLenght] == sequence)
                        {
                            sequenceLenght++;
                            if (sequenceLenght > maxSequenceLenght)
                            {
                                maxSequenceLenght = sequenceLenght;
                                maxSequence = sequence;
                            }
                            check = true;
                        }
                    }
                } while (check);

                //checking down
                sequenceLenght = 1;
                do
                {
                    check = false;
                    if (i + sequenceLenght < mat.GetLength(0))
                    {
                        if (mat[i + sequenceLenght, j] == sequence)
                        {
                            sequenceLenght++;
                            if (sequenceLenght > maxSequenceLenght)
                            {
                                maxSequenceLenght = sequenceLenght;
                                maxSequence = sequence;
                            }
                            check = true;
                        }
                    }
                } while (check);

                //checking left down diagonal
                sequenceLenght = 1;
                do
                {
                    check = false;
                    if ((i+sequenceLenght<mat.GetLength(0))&&(j - sequenceLenght >= 0))
                    {
                        if (mat[i + sequenceLenght, j - sequenceLenght] == sequence)
                        {
                            sequenceLenght++;
                            if (sequenceLenght > maxSequenceLenght)
                            {
                                maxSequenceLenght = sequenceLenght;
                                maxSequence = sequence;
                            }
                            check = true;
                        }
                    }
                } while (check);
            }
        }

        for (int i = 0; i < maxSequenceLenght; i++)
        {
            display += maxSequence;
            if (i < maxSequenceLenght - 1)
            {
                display += ", ";
            }
        }
        Console.WriteLine("The bigest seqence is {0}", display);

    }
}
