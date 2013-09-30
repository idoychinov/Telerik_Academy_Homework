using System;


// This class is the main application class. It uses all other classes defined in the homework and calls the test classes in the main method to test all the functionalites.
// The other classes contain comments that describe which particular problems from the homework are addressed in the class.

namespace MobilePhoneApplication
{
    class MobilePhoneApplication
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to test GSM functionality...");
            Console.ReadKey(true);
            GSMTest.TestAll();
            Console.WriteLine("Press any key to test CallHistory functionality...");
            Console.ReadKey(true);
            GSMCallHistoryTest.TestAll();
            Console.WriteLine("Press any key to exit!");
            Console.ReadKey(true);
        }
    }
}
