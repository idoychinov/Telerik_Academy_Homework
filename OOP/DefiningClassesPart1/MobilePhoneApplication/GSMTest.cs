using System;

//Write a class GSMTest to test the GSM class:
//Create an array of few instances of the GSM class.
//Display the information about the GSMs in the array.
//Display the information about the static property IPhone4S.

namespace MobilePhoneApplication
{
    public static class GSMTest
    {
        public static void TestAll()
        {
            GSM[] gsmArray = new GSM[3];
            gsmArray[0] = new GSM("Galaxy S4","Samsung");
            gsmArray[1] = new GSM("Lumia 1020", "Nokia", 500.2453M, "Pesho", new Battery("BV-5XW"), new Display());
            gsmArray[2] = new GSM("One", "HTC");

            gsmArray[2].Owner = "Gosho";
            gsmArray[2].Price = 15.512M;
            Battery battery = new Battery("N/A", 500, 27, null);
            Display display = new Display("1080x1920", 16000000);
            gsmArray[2].BatteryCharacteristics = battery;
            gsmArray[2].DisplayCharacteristics = display;

            foreach (var item in gsmArray)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(GSM.IPhone4S.ToString());
        }
    }
}
