using System.Collections.Generic;

namespace ConsoleApplication1.Problem_2
{
    internal interface IPhonebookRepository
    {
        bool AddPhone(string name,
            IEnumerable<string> phoneNumbers);

        int ChangePhone(
            string oldPhoneNumber, string newPhoneNumber);

        Class1[] ListEntries(int startIndex, int count);
    }
}