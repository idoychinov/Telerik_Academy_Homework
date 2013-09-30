using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneApplication
{

    // Problem 12. Write a class GSMCallHistoryTest to test the call history functionality of the GSM class.
    //Create an instance of the GSM class.
    //Add few calls.
    //Display the information about the calls.
    //Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
    //Remove the longest call from the history and calculate the total price again.
    //Finally clear the call history and print it.

    public static class GSMCallHistoryTest
    {
        public static void TestAll()
        {
            GSM myGSM = new GSM("3310", "Nokia");

            myGSM.AddCall(new Call(DateTime.Now, "345333546", 145));
            myGSM.AddCall(new Call(DateTime.Now - TimeSpan.FromDays(2), "435435435", 623));
            myGSM.AddCall(new Call(DateTime.Now - TimeSpan.FromHours(431), "345435", 1231));

            PrintCallHistory(myGSM);
            Console.WriteLine("Total call price is {0:0.00}", myGSM.TotalCallPrice(0.37M));

            int indexofMax=0;
            for (int i = 1; i < myGSM.CallHistory.Count; i++)
            {
                if (myGSM.CallHistory[i].Duration > myGSM.CallHistory[indexofMax].Duration)
                {
                    indexofMax = i;
                }
            }
            myGSM.DeleteCall(indexofMax+1);
            Console.WriteLine("Total call price without the longest call is {0:0.00}",myGSM.TotalCallPrice(0.37M));
            myGSM.ClearCallHistory();
            PrintCallHistory(myGSM);
        }

        private static void PrintCallHistory(GSM gsm)
        {
            foreach (var item in gsm.CallHistory)
            {
                Console.WriteLine("Call time: {0}\nCalled Number: {1}\nCall Duration: {2}\n", item.DateAndTime, item.DialedPhone, item.Duration);
            }
        }
    }


}
