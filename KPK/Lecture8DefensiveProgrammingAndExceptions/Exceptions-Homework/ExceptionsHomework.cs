using System;
using System.Collections.Generic;
using System.Text;

public class ExceptionsHomework
{
    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        if (arr == null)
        {
            throw new ArgumentNullException("arr is null");
        }

        if (arr.Length == 0)
        {
            return new List<T>().ToArray();
        }

        if (startIndex < 0 || startIndex > arr.Length - 1)
        {
            throw new ArgumentOutOfRangeException("Start index must be in the range of 0 to arr.lenght-1");
        }

        if (count < 0 || count + startIndex > arr.Length + 1)
        {
            throw new ArgumentOutOfRangeException("Count must be equal or greater than 0 and startIndex plus count must be less than arr.lenght-1");
        }

        List<T> result = new List<T>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (str == null)
        {
            throw new ArgumentNullException("Str is null");
        }

        if (count > str.Length)
        {
            throw new ArgumentOutOfRangeException("Count. Parameter must be less than or equal to str.Length");
        }

        StringBuilder result = new StringBuilder();
        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        return result.ToString();
    }

    public static bool CheckPrime(int number)
    {
        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                return false;
            }
        }

        return true;
    }

    public static void Main()
    {
        var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(substr);

        var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
        Console.WriteLine(string.Join(" ", subarr));

        var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
        Console.WriteLine(string.Join(" ", allarr));

        var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
        Console.WriteLine(string.Join(" ", emptyarr));

        Console.WriteLine(ExtractEnding("I love C#", 2));
        Console.WriteLine(ExtractEnding("Nakov", 4));
        Console.WriteLine(ExtractEnding("beer", 4));

        // Console.WriteLine(ExtractEnding("Hi", 100)); // throwing exemption count is greater then the lenght of the input string

        ////try
        ////{
        ////    CheckPrime(23);
        ////    Console.WriteLine("23 is prime.");
        ////}
        ////catch (Exception ex)
        ////{
        ////    Console.WriteLine("23 is not prime");
        ////}

        ////try
        ////{
        ////    CheckPrime(33);
        ////    Console.WriteLine("33 is prime.");
        ////}
        ////catch (Exception ex)
        ////{
        ////    Console.WriteLine("33 is not prime");
        ////}

        Console.WriteLine("23 is {0}", CheckPrime(23) ? "prime" : "not prime");
        Console.WriteLine("33 is {0}", CheckPrime(33) ? "prime" : "not prime");

        List<IExam> peterExams = new List<IExam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
        Student peter = new Student("Peter", "Petrov", peterExams);
        double peterAverageResult = peter.CalcAverageExamResultInPercents();
        Console.WriteLine("Average results = {0:p0}", peterAverageResult);
    }
}
