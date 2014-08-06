namespace ComputerBuildingSystem.Core
{
    using System;
    using ComputerBuildingSystem.Core.Interfaces;

    public abstract class HardDriveComponent : IHardDrive
    {
        private int capacity;

        public HardDriveComponent(int capacity)
        {
            this.capacity = capacity;
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            private set
            {
                this.capacity = value;
            }
        }

        public abstract void SaveData(string data, int addres);

        public abstract string GetData(int addres);

    }
}
