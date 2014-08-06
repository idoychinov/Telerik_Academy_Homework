namespace ComputerBuildingSystem.Core
{
    using System;

    public class DellFactory : ComputerManifacturer
    {
        private const int PcAndLaptopCores = 4;
        private const int PcAndLaptopRamCapacity = 8;
        private const int PcAndLaptopHddCapacity = 1000;
        private const int ServerCores = 8;
        private const int ServerRamCapacity = 64;
        private const int ServerHddCapacity = 2000;
        private const int NumberOfDisksInServerRaid = 2;

        public override PC ManifacturePC()
        {
            var cpu = new Cpu64Bit(PcAndLaptopCores, this.RandomGenerator);
            var ramMemory = new RamMemory(PcAndLaptopRamCapacity);
            var hardDisk = new Hdd(PcAndLaptopHddCapacity);
            var videoCard = new ColorfulVideoCard();
            var motherBoard = new Motherboard(ramMemory, hardDisk, videoCard);
            var pc = new PC(cpu, motherBoard);
            return pc;
        }

        public override Server ManifactureServer()
        {
            var cpu = new Cpu64Bit(ServerCores, this.RandomGenerator);
            var ramMemory = new RamMemory(ServerRamCapacity);
            var hardDisk = new RaidArray(ServerHddCapacity, NumberOfDisksInServerRaid);
            var videoCard = new MonochromeVideoCard();
            var motherBoard = new Motherboard(ramMemory, hardDisk, videoCard);
            var server = new Server(cpu, motherBoard);
            return server;
        }

        public override Laptop ManifactureLaptop()
        {
            var cpu = new Cpu32Bit(PcAndLaptopCores, this.RandomGenerator);
            var ramMemory = new RamMemory(PcAndLaptopRamCapacity);
            var hardDisk = new Hdd(PcAndLaptopHddCapacity);
            var videoCard = new ColorfulVideoCard();
            var battery = new LaptopBattery();
            var motherBoard = new Motherboard(ramMemory, hardDisk, videoCard);
            var laptop = new Laptop(cpu, motherBoard, battery);
            return laptop;
        }
    }
}