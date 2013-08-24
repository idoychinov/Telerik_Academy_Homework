/* Problem 3. A company has name, address, phone number, fax number, web site and manager. The manager has first name, last name, age and a phone number. 
 * Write a program that reads the information about a company and its manager and prints them on the console.
 */

using System;

class Company
{
    static void Main()
    {
        string cName, cAddress, cPhone, cFax, cSite, mFirstName, mLastName, mAge, mPhone;
        Console.Write("Enter company's name: ");
        cName= Console.ReadLine();
        Console.Write("Enter company's address: ");
        cAddress = Console.ReadLine();
        Console.Write("Enter company's phone number: ");
        cPhone = Console.ReadLine();
        Console.Write("Enter company's fax number: ");
        cFax = Console.ReadLine();
        Console.Write("Enter company's web site: ");
        cSite = Console.ReadLine();
        Console.Write("Enter manager's first name: ");
        mFirstName = Console.ReadLine();
        Console.Write("Enter manager's last name: ");
        mLastName = Console.ReadLine();
        Console.Write("Enter manager's age: ");
        mAge = Console.ReadLine();
        Console.Write("Enter manager's phone number: ");
        mPhone = Console.ReadLine();

        Console.WriteLine("\nCompany details: \nName: {0}\nAddress: {1}\nPhone: {2}\nFax: {3}\nWeb Site: {4}",cName,cAddress,cPhone,cFax,cSite);
        Console.WriteLine("The company's manager is {0} {1}, age {2}. His phone number is {3}",mFirstName,mLastName,mAge,mPhone);
    }
}

