using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.UsingVariables
{
    public class Print {
    public void PrintStatistics(double[] array, int numberOfElements)
{
    double maximumNumber=array[0];
    for (int i = 1; i < numberOfElements; i++)
    {
        if (array[i] > maximumNumber)
        {
            maximumNumber = array[i];
        }
    }
    PrintMax(maximumNumber);

    double minimumNumber = 0;
    for (int i = 0; i < numberOfElements; i++)
    {
        if (array[i] < minimumNumber)
        {
            minimumNumber = array[i];
        }
    }
    PrintMin(minimumNumber);

    double sum = 0;
    for (int i = 0; i < numberOfElements; i++)
    {
        sum += array[i];
    }
    PrintAvg(sum / numberOfElements);
}

    private void PrintMax(double number) { Console.WriteLine("Maximum number is {0}",number); }
    private void PrintMin(double number) { Console.WriteLine("Minimum number is {0}", number); }
    private void PrintAvg(double number) { Console.WriteLine("Sum is {0}", number); }

}


}
