/* Problem 14. A bank account has a holder name (first name, middle name and last name), available amount of money (balance), bank name, IBAN, BIC code and 3 credit card numbers associated with the account.
 * Declare the variables needed to keep the information for a single bank account using the appropriate data types and descriptive names.
 */
using System;

class BankAccount
{
    static void Main()
    {
        // all the variables should be string since any of them can contain symbols with the exception of balance which should be decimal to ensure correct floating point operations with it.
        string firstName;
        string middleName;
        string lastName;
        decimal balance;
        string bankName;
        string iban;
        string bicCode;
        string creditCard1;
        string creditCard2;
        string creditCard3;
    }
}

