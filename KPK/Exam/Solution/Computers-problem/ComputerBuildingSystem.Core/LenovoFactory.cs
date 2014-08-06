namespace ComputerBuildingSystem.Core
{
    public class LenovoFactory : ComputerManifacturer
    {
        private const int NumberOfCores = 2;
        private const int PcRamCapacity = 4;
        private const int LaptopRamCapacity = 8;
        private const int PcHddCapacity = 2000;
        private const int ServerRamCapacity = 16;
        private const int ServerHddCapacity = 500;
        private const int LaptopHddCapacity = 1000;
        private const int NumberOfDisksInServerRaid = 2;


        public override PC ManifacturePC()
        {
            var cpu = new Cpu64Bit(NumberOfCores, this.randomProvider);
            var ramMemory = new RamMemory(PcRamCapacity);
            var hardDisk = new Hdd(PcHddCapacity);
            var videoCard = new MonochromeVideoCard();
            var motherBoard = new Motherboard(ramMemory, hardDisk, videoCard);
            var pc = new PC(cpu, motherBoard);
            return pc;
        }

        public override Server ManifactureServer()
        {
            var cpu = new Cpu128Bit(NumberOfCores, this.randomProvider);
            var ramMemory = new RamMemory(ServerRamCapacity);
            var hardDisk = new RaidArray(ServerHddCapacity, NumberOfDisksInServerRaid);
            var videoCard = new MonochromeVideoCard();
            var motherBoard = new Motherboard(ramMemory, hardDisk, videoCard);
            var server = new Server(cpu, motherBoard);
            return server;
        }

        public override Laptop ManifactureLaptop()
        {
            var cpu = new Cpu64Bit(NumberOfCores, this.randomProvider);
            var ramMemory = new RamMemory(LaptopRamCapacity);
            var hardDisk = new Hdd(LaptopHddCapacity);
            var videoCard = new ColorfulVideoCard();
            var battery = new LaptopBattery();
            var motherBoard = new Motherboard(ramMemory, hardDisk, videoCard);
            var laptop = new Laptop(cpu, motherBoard, battery);
            return laptop;
        }
    }
}
