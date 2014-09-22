namespace DateTimeService.Host
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Description;

    class Host
    {
        private static readonly string Url = "http://127.0.0.1:4567";

        private static readonly ServiceMetadataBehavior Behavior = new ServiceMetadataBehavior();

        static void Main()
        {
            Console.WriteLine(@"Plese start the Host.ext from the \Bin\Debug\ folder of this project with administrator rights to start the service.");

            ServiceHost host = new ServiceHost(typeof(DateTimeService),new Uri(Url));

            Behavior.HttpGetEnabled = true;
            host.Description.Behaviors.Add(Behavior);
            
            host.Open();
            Console.WriteLine("DateTime Service running at {0}\nPress any key to exit.", Url);
            Console.ReadKey();
            host.Close();
        }
    }
}
