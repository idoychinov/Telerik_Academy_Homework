namespace ComputerBuildingSystem.Core
{
    public class HPFactory : ComputerManifacturer
    {
        private const int PcAndLaptopCores = 2;
        private const int PcRamCapacity = 2;
        private const int LaptopRamCapacity = 4;
        private const int PcAndLaptopHddCapacity = 500;
        private const int ServerCores = 4;
        private const int ServerRamCapacity = 32;
        private const int ServerHddCapacity = 1000;
        private const int NumberOfDisksInServerRaid = 2;

        public override PC ManifacturePC()
        {
            var cpu = new Cpu32Bit(PcAndLaptopCores, this.RandomGenerator);
            var ramMemory = new RamMemory(PcRamCapacity);
            var hardDisk = new Hdd(PcAndLaptopHddCapacity);
            var videoCard = new ColorfulVideoCard();
            var motherBoard = new Motherboard(ramMemory, hardDisk, videoCard);
            var pc = new PC(cpu, motherBoard);
            return pc;
        }

        public override Server ManifactureServer()
        {
            var cpu = new Cpu32Bit(ServerCores, this.RandomGenerator);
            var ramMemory = new RamMemory(ServerRamCapacity);
            var hardDisk = new RaidArray(ServerHddCapacity, NumberOfDisksInServerRaid);
            var videoCard = new MonochromeVideoCard();
            var motherBoard = new Motherboard(ramMemory, hardDisk, videoCard);
            var server = new Server(cpu, motherBoard);
            return server;
        }

        public override Laptop ManifactureLaptop()
        {
            var cpu = new Cpu64Bit(PcAndLaptopCores, this.RandomGenerator);
            var ramMemory = new RamMemory(LaptopRamCapacity);
            var hardDisk = new Hdd(PcAndLaptopHddCapacity);
            var videoCard = new ColorfulVideoCard();
            var battery = new LaptopBattery();
            var motherBoard = new Motherboard(ramMemory, hardDisk, videoCard);
            var laptop = new Laptop(cpu, motherBoard, battery);
            return laptop;
        }
    }
}
