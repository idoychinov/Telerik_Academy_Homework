namespace ComputerBuildingSystem.Core
{
    using System;
    using System.Collections.Generic;

    public class Hdd : HardDriveComponent
    {
        private readonly IDictionary<int, string> data;

        public Hdd(int capacity)
            : base(capacity)
        {
            this.data = new Dictionary<int, string>(this.Capacity);
        }

        public override void SaveData(string data, int addres)
        {
            // TODO : Error Check
            this.data.Add(addres, data);
        }

        public override string GetData(int addres)
        {
            // TODO : Error Check
            return this.data[addres];
        }
    }
}
