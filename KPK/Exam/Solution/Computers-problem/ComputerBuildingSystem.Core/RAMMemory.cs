namespace ComputerBuildingSystem.Core
{
    using System;
    using ComputerBuildingSystem.Core.Interfaces;

    public class RamMemory : IRamMemory
    {
        private int amount;

        public RamMemory(int amount)
        {
            this.Amount = amount;
        }

        public int Amount
        {
            get
            {
                return this.amount;
            }

            private set
            {
                this.amount = value;
            }
        }

        public int CurrentValue { get; set; }
    }
}
