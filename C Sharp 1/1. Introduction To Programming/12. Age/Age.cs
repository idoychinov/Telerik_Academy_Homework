// 12. *Write a program to read your age from the console and print how old you will be after 10 years.

using System;

class Age
{
    static void Main()
    {
        while (true) // Infinite loop that will end after correct value is entered.
        {
            Console.WriteLine("Enter your age: ");
            string line = Console.ReadLine();
            int age;
            if (int.TryParse(line, out age))  // Checks if the entered value can be converted to integer 
            {
                if (age > 0)
                {
                    Console.WriteLine("You will be {0} years old after 10 years. ", age + 10);
                    break;  // Exits the loop after a correct value is entered and the result is displayed.
                }
                else
                {
                    Console.WriteLine("Your age must be positive integer number!");
                }
            }
            else
            {
                Console.WriteLine("Please enter a positive integer number for your age!");
            }
            Console.WriteLine();
        }

    }
}
