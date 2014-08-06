namespace ComputerBuildingSystem.Core
{
    using System;
    using ComputerBuildingSystem.Core.Interfaces;

    public class Motherboard : IMotherboard
    {
        private IRamMemory ram;
        private IHardDrive hardDriveComponent;
        private IVideoCard videoCard;

        public Motherboard(IRamMemory ram, IHardDrive hardDriveComponent, IVideoCard videoCard)
        {
            this.ram = ram;
            this.hardDriveComponent = hardDriveComponent;
            this.videoCard = videoCard;
        }

        public int LoadRamValue()
        {
            return this.ram.CurrentValue;
        }

        public void SaveRamValue(int value)
        {
            this.ram.CurrentValue = value;
        }

        public void DrawOnVideoCard(string data)
        {
            this.videoCard.DrawText(data);
        }
    }
}
