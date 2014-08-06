namespace ComputerBuildingSystem.Core
{
    using System;
    using ComputerBuildingSystem.Core.Interfaces;

    public class LaptopBattery : IBattery
    {
        private const int MinPower = 0;
        private const int MaxPower = 100;
        private const int InnitialPower = 50;
        private int currentPower;

        public LaptopBattery()
        {
            this.currentPower = InnitialPower;
        }

        public void Charge(int chargeAmount)
        {
            var chargedPower = this.currentPower + chargeAmount;

            if (chargedPower > MaxPower)
            {
                chargedPower = MaxPower;
            }
            else if (chargedPower < MinPower)
            {
                chargedPower = MinPower;
            }

            this.currentPower = chargedPower;
        }

        public int CurrentPower()
        {
            return this.currentPower;
        }
    }
}
