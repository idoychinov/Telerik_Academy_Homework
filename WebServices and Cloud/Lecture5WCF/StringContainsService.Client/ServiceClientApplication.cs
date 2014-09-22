namespace StringContainsService.Client
{
    using System;
    using StringContainsService.Client.StringContainsServiceReference;
    class ServiceClientApplication
    {
        const string text = "ala bala nica ala ba nla";
        const string searchString = "ala";

        static void Main()
        {
            // Please start the StringContainsService first. You can use right click -> view in browser on StringContainsService.svc
            var client = new StringContainsServiceClient();
            
            Console.WriteLine("The text: {0}, contains the string {1} {2} times",
                text,
                searchString,
                client.GetNumberOccurrences(text, searchString));

            Console.WriteLine("\nEnter text you want to search in:");
            var textToSearchIn = Console.ReadLine();
            Console.WriteLine("Enter text you want to search for:");
            var textToSearchFor = Console.ReadLine();

            Console.WriteLine("The text: {0}, contains the string {1} {2} times",
                textToSearchIn,
                textToSearchFor,
                client.GetNumberOccurrences(textToSearchIn, textToSearchFor));
        }
    }
}
