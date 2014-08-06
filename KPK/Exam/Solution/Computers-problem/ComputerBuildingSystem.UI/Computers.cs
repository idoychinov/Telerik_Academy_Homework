namespace ComputersBuildingSystem
{
    using System;
    using ComputerBuildingSystem.Core;
    using ComputerBuildingSystem.Core.Interfaces;

    internal class Computers
    {
        public static void Main()
        {
            ComputerManifacturer computerManifacturerFactory;
            IComputer pc, laptop, server;
            var manufacturer = Console.ReadLine();

            if (manufacturer == "HP")
            {
                computerManifacturerFactory = new HPFactory();
            }
            else if (manufacturer == "Dell")
            {
                computerManifacturerFactory = new DellFactory();
            }
            else if (manufacturer == "Lenovo")
            {
                computerManifacturerFactory = new LenovoFactory();
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid manufacturer!");
            }

            pc = computerManifacturerFactory.ManifacturePC();
            laptop = computerManifacturerFactory.ManifactureLaptop();
            server = computerManifacturerFactory.ManifactureServer();

            var command = Console.ReadLine();
            while (!(command == null || command.StartsWith("Exit")))
            {
                var commandParameters = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (commandParameters.Length != 2)
                {
                    {
                        throw new ArgumentException("Invalid command!");
                    }
                }

                var commandName = commandParameters[0];
                var commandAction = int.Parse(commandParameters[1]);

                if (commandName == "Charge")
                {
                    laptop.Interact(commandAction);
                }
                else if (commandName == "Process")
                {
                    server.Interact(commandAction);
                }
                else if (commandName == "Play")
                {
                    pc.Interact(commandAction);
                }

                command = Console.ReadLine();
            }
        }
    }
}