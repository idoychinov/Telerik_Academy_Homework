namespace ComputerBuildingSystem.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RaidArray : HardDriveComponent
    {
        private readonly IList<HardDriveComponent> hardDrives;

        public RaidArray(int capacity, int numberOfDisks)
            : base(capacity)
        {
            this.hardDrives = new List<HardDriveComponent>(capacity);
            for (var i = 0; i < numberOfDisks; i++)
            {
                this.hardDrives.Add(new Hdd(capacity));
            }
        }

        public override void SaveData(string data, int addres)
        {
            if (this.hardDrives.Count > 0)
            {
                foreach (var hardDrive in this.hardDrives)
                {
                    hardDrive.SaveData(data, addres);
                }
            }
            else
            {
                throw new InvalidOperationException("No hard drive in the RAID array!");
            }
        }

        public override string GetData(int addres)
        {
            if (this.hardDrives.Count > 0)
            {
                var data = this.hardDrives.First().GetData(addres);
                return data;
            }
            else
            {
                throw new InvalidOperationException("No hard drive in the RAID array!");
            }
        }
    }
}
