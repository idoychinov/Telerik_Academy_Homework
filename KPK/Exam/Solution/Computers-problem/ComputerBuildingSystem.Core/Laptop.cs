namespace ComputerBuildingSystem.Core
{
    using ComputerBuildingSystem.Core.Interfaces;

    public class Laptop : Computer
    {
        private IBattery battery;

        public Laptop(ICpu cpu, IMotherboard motherboard, IBattery battery)
            : base(cpu, motherboard)
        {
            this.battery = battery;
        }

        public override void Interact(int parameter)
        {
            this.ChargeBattery(parameter);
        }

        private void ChargeBattery(int parameter)
        {
            this.battery.Charge(parameter);
            this.Motherboard.DrawOnVideoCard(string.Format("Battery status: {0}", this.battery.CurrentPower()));
        }
    }
}
